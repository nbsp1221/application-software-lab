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

        public void getCookies()
        {
            restService.getCookies();
        }



        /// <summary>
        /// 메인 페이지 - 모든 학기에 대한 과목 정보 얻기
        /// </summary>
        /// <returns></returns>
        public Task<Dictionary<string, List<LectureInfo>>> GetAllSemesterLectures()
        {
            return restService.GetAllSemesterLectures();
        }

        /// <summary>
        /// 강의 계획서 페이지 - 학과 정보 얻기
        /// </summary>
        /// <returns></returns>
        public Task<List<DepartmentInfo>> GetAllDepartments(int year, int semester)
        {
            return restService.GetAllDepartments(year, semester);
        }

        /// <summary>
        /// 강의 계획서 페이지 - 강의 계획서 검색
        /// </summary>
        /// <param name="syllabusSearchInfo">강의 계획서 검색에 필요한 정보</param>
        /// <returns></returns>
        public Task<List<SyllabusInfo>> SearchSyllabus(SyllabusSearchInfo syllabusSearchInfo)
        {
            return restService.SearchSyllabus(syllabusSearchInfo);
        }

        /// <summary>
        /// 수강 / 성적 조회 페이지 - 성적 정보 얻기
        /// </summary>
        /// <returns></returns>
        public Task<Dictionary<string, List<ScoreInfo>>> GetAllSemesterScores()
        {
            return restService.GetAllSemesterScores();
        }
    }
}
