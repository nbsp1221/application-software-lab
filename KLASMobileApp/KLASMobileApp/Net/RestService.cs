using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace KLASMobileApp.Net
{
    public class RestService : IRestService
    {
        public HttpClient client;

        public RestService()
        {
            client = new HttpClient();
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
            }catch(Exception e)
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
                    loginPwd=pw, storeIdYn="N"});


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

                    HttpResponseMessage response2 = await client.PostAsync(new Uri(Constants.Constants.Url_LoginConfirm) ,
                            new StringContent(content,Encoding.UTF8, "application/json"));
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
                    catch(Exception e)
                    {
                        Debug.WriteLine(@"\tERROR {0}", e.Message);
                        return false;
                    }
                }
            }catch(Exception e)
            {
                Debug.WriteLine(@"\tERROR {0}", e.Message);
                return false;
            }
            return false;
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
    }
}
