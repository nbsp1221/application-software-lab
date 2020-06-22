using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KLASMobileApp.Data;

namespace KLASMobileApp.Net
{
    public class RestManager
    {
        IRestService restService;

        public RestManager(IRestService service)
        {
            restService = service;
        }

        public Task<bool> LoginSecurity(string id, string pw)
        {
            return restService.LoginSecurity(id, pw);
        }

        public Task<string> GetSchdulInfo(string yearHakgi, string subject)
        {
            return restService.GetSchdulInfo(yearHakgi, subject);
        }

        public Task<LecturesBean> GetStdInfo()
        {
            return restService.GetStdInfo();
        }

        /// <summary>
        /// 모든 학기에 대한 과목 정보 얻기
        /// </summary>
        /// <returns></returns>
        public Task<Dictionary<string, List<LectureInfo>>> GetAllSemesterLectures()
        {
            return restService.GetAllSemesterLectures();
        }
    }
}
