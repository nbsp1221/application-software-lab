using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KLASMobileApp.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Xamarin.Android.Net;

namespace KLASMobileApp.Net
{
    public class RestService : IRestService
    {
        public HttpClient client;
        public HttpClientHandler handler;
        public CookieContainer cookies;

        public RestService()
        {
            cookies = new CookieContainer();
            handler = new AndroidClientHandler
            {
                UseCookies = true,
                CookieContainer = cookies
            };
            handler.CookieContainer = cookies;

            //client = new HttpClient(handler);
            client = new HttpClient(handler);
            //client.DefaultRequestHeaders.


        }

        public void getCookies()
        {
            Uri uri = new Uri("https://klas.kw.ac.kr");
            IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();

            foreach (Cookie cookie in responseCookies)
                Console.WriteLine(cookie.Name + ": " + cookie.Value);

        }

        public async Task<string> GetSchdulInfo(string yearHakgi, string subject)
        {
            try
            {
                string content = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    selectYearhakgi = yearHakgi,
                    selectSubj = subject
                });

                HttpResponseMessage response = await client.PostAsync(new Uri(Constants.Constants.Url_LctrumSchdulInfo),
                    new StringContent(content, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string value = await response.Content.ReadAsStringAsync();
                    return value;
                }
                else
                {
                    return "";
                }
            } catch (Exception e)
            {
                return "";
            }
        }

        public async Task<LecturesBean> GetStdInfo()
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync(new Uri(Constants.Constants.Url_StdHome), new StringContent("", Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {

                    string value = await response.Content.ReadAsStringAsync();

                    List<LectureData> lecturelist = JsonConvert.DeserializeObject<List<LectureData>>(JObject.Parse(value)["atnlcSbjectList"].ToString());
                    List<TimeTableData> timeTableList = JsonConvert.DeserializeObject<List<TimeTableData>>(JObject.Parse(value)["timeTableList"].ToString());
                    List<NotiData> notiList = JsonConvert.DeserializeObject<List<NotiData>>(JObject.Parse(value)["subjNotiList"].ToString());
                    ProfessorData professorData = JsonConvert.DeserializeObject<ProfessorData>(JObject.Parse(value)["rspnsblProfsr"].ToString());

                    LecturesBean bean = new LecturesBean();

                    bean.lectureList = lecturelist;
                    bean.timeTableData = timeTableList;
                    bean.notiList = notiList;
                    bean.professorData = professorData;
                    return bean;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> LoginSecurity(string id, string pw)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(new Uri(Constants.Constants.Url_LoginSecurity));

                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync();

                    string key = JObject.Parse(res)["publicKey"].ToString();
                    string value = Newtonsoft.Json.JsonConvert.SerializeObject(new { loginId = id,
                        loginPwd = pw, storeIdYn = "N" });


                    Asn1Object obj = Asn1Object.FromByteArray(Convert.FromBase64String(key));

                    DerSequence publicKeySequence = (DerSequence)obj;

                    DerBitString encodedPublicKey = (DerBitString)publicKeySequence[1];
                    DerSequence publicKey = (DerSequence)Asn1Object.FromByteArray(encodedPublicKey.GetBytes());

                    var modulus = publicKey[0];
                    var exponent = publicKey[1];

                    RsaKeyParameters keyParameters = new RsaKeyParameters(false, ((DerInteger)modulus).PositiveValue, ((DerInteger)exponent).PositiveValue);
                    RSAParameters parameters = DotNetUtilities.ToRSAParameters(keyParameters);


                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    rsa.ImportParameters(parameters);

                    //암호화할 문자열을 UFT8인코딩
                    byte[] inbuf = (new UTF8Encoding()).GetBytes(value);

                    //암호화
                    byte[] encbuf = rsa.Encrypt(inbuf, false);

                    //암호화된 문자열 Base64인코딩
                    string token = System.Convert.ToBase64String(encbuf);

                    string content = Newtonsoft.Json.JsonConvert.SerializeObject(new
                    {
                        loginToken = token,
                        redirectUrl = "",
                        redirectTabUrl = "",
                    });

                    HttpResponseMessage response2 = await client.PostAsync(new Uri(Constants.Constants.Url_LoginConfirm),
                            new StringContent(content, Encoding.UTF8, "application/json"));
                    try
                    {
                        if (response2.IsSuccessStatusCode) {
                            string res2 = await response2.Content.ReadAsStringAsync();

                            if (JObject.Parse(res2)["errorCount"].ToString() == "0")
                                return true;
                            else
                                return false;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(@"\tERROR {0}", e.Message);
                        return false;
                    }
                }
            } catch (Exception e)
            {
                Debug.WriteLine(@"\tERROR {0}", e.Message);
                return false;
            }
            return false;
        }





        public async Task<string> UpdateToken(string studentCode, string mobileToken)
        {
            try
            {
                string content = JsonConvert.SerializeObject(new
                {
                    studentCode = studentCode,
                    mobileToken = mobileToken
                });

                HttpResponseMessage response = await client.PostAsync(
                    new Uri(Constants.Constants.URL_UpdateToken),
                    new StringContent(content, Encoding.UTF8, "application/json")
                );

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine("\tUpdateToken() ERROR - {0}", e.Message);
                return null;
            }
        }

        public async Task<Dictionary<string, List<LectureInfo>>> GetAllSemesterLectures()
        {
            try
            {
                Dictionary<string, List<LectureInfo>> allSemesterLectures = new Dictionary<string, List<LectureInfo>>();

                HttpResponseMessage response = await client.PostAsync(
                    new Uri(Constants.Constants.URL_AllSemesterLectures),
                    new StringContent("{}", Encoding.UTF8, "application/json")
                );

                if (response.IsSuccessStatusCode)
                {
                    string jsonValue = await response.Content.ReadAsStringAsync();

                    foreach (JToken jTokenSemester in JArray.Parse(jsonValue))
                    {
                        List<LectureInfo> lectureInfos = new List<LectureInfo>();

                        foreach (JToken jTokenLecture in jTokenSemester["subjList"])
                        {
                            lectureInfos.Add(new LectureInfo(
                                jTokenLecture["name"].ToString(),
                                jTokenLecture["label"].ToString(),
                                jTokenLecture["value"].ToString()
                            ));
                        }

                        allSemesterLectures[jTokenSemester["value"].ToString()] = lectureInfos;
                    }
                }

                return allSemesterLectures;
            }
            catch (Exception e)
            {
                Debug.WriteLine("\tGetAllSemesterLectures() ERROR - {0}", e.Message);
                return null;
            }
        }

        public async Task<List<DepartmentInfo>> GetAllDepartments(int year, int semester)
        {
            try
            {
                List<DepartmentInfo> allDepartments = new List<DepartmentInfo>();

                string content = JsonConvert.SerializeObject(new
                {
                    selectYear = year,
                    selecthakgi = semester
                });

                HttpResponseMessage response = await client.PostAsync(
                    new Uri(Constants.Constants.URL_AllDepartments),
                    new StringContent(content, Encoding.UTF8, "application/json")
                );

                if (response.IsSuccessStatusCode)
                {
                    string jsonValue = await response.Content.ReadAsStringAsync();

                    foreach (JToken jTokenDepartment in JArray.Parse(jsonValue))
                    {
                        allDepartments.Add(new DepartmentInfo(
                            jTokenDepartment["classCode"].ToString(),
                            jTokenDepartment["openMajorName"].ToString(),
                            jTokenDepartment["openMajorNameSub"].ToString()
                        ));
                    }
                }

                return allDepartments;
            }
            catch (Exception e)
            {
                Debug.WriteLine("\tGetAllDepartments() ERROR - {0}", e.Message);
                return null;
            }
        }

        public async Task<List<SyllabusInfo>> SearchSyllabus(SyllabusSearchInfo syllabusSearchInfo)
        {
            try
            {
                List<SyllabusInfo> syllabusInfos = new List<SyllabusInfo>();

                string content = JsonConvert.SerializeObject(new
                {
                    selectYear = syllabusSearchInfo.Year,
                    selecthakgi = syllabusSearchInfo.Semester,
                    selectRadio = syllabusSearchInfo.IsMyLecture ? "my" : "all",
                    selectText = syllabusSearchInfo.LectureName,
                    selectProfsr = syllabusSearchInfo.ProfessorName,
                    cmmnGamok = "",
                    selecthakgwa = syllabusSearchInfo.DepartmentCode,
                    selectMajor = "",
                    selectMajorList = ""
                });

                HttpResponseMessage response = await client.PostAsync(
                    new Uri(Constants.Constants.URL_SearchSyllabus),
                    new StringContent(content, Encoding.UTF8, "application/json")
                );

                if (response.IsSuccessStatusCode)
                {
                    string jsonValue = await response.Content.ReadAsStringAsync();

                    foreach (JToken jToken in JArray.Parse(jsonValue))
                    {
                        syllabusInfos.Add(new SyllabusInfo(jToken));
                    }
                }

                return syllabusInfos;
            }
            catch (Exception e)
            {
                Debug.WriteLine("\tSearchSyllabus() ERROR - {0}", e.Message);
                return null;
            }
        }

        public async Task<Dictionary<string, List<ScoreInfo>>> GetAllSemesterScores()
        {
            try
            {
                Dictionary<string, List<ScoreInfo>> allSemesterScores = new Dictionary<string, List<ScoreInfo>>();

                HttpResponseMessage response = await client.PostAsync(
                    new Uri(Constants.Constants.URL_AllSemesterScores),
                    new StringContent("{}", Encoding.UTF8, "application/json")
                );

                if (response.IsSuccessStatusCode)
                {
                    string jsonValue = await response.Content.ReadAsStringAsync();

                    foreach (JToken jTokenSemester in JArray.Parse(jsonValue))
                    {
                        List<ScoreInfo> scoreInfos = new List<ScoreInfo>();

                        foreach (JToken jTokenScore in jTokenSemester["sungjukList"])
                        {
                            scoreInfos.Add(new ScoreInfo(jTokenScore));
                        }

                        allSemesterScores[string.Format("{0},0{1}", jTokenSemester["thisYear"], jTokenSemester["hakgi"])] = scoreInfos;
                    }
                }

                return allSemesterScores;
            }
            catch (Exception e)
            {
                Debug.WriteLine("\tGetAllSemesterScores() ERROR - {0}", e.Message);
                return null;
            }
        }
    }
}
