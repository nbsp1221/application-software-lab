using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using KLASMobileApp.Data;

namespace KLASMobileApp.Net
{
    public interface IRestService
    {
        void getCookies();

        Task<bool> LoginSecurity(string id, string pw);
        
        Task<String> GetSchdulInfo(string yearHakgi, string subject);

        Task<LecturesBean> GetStdInfo();




        /// <summary>
        /// 알림 서버 - 토큰 추가 및 업데이트
        /// </summary>
        /// <param name="studentCode">학번</param>
        /// <param name="mobileToken">특정 기기의 토큰</param>
        /// <returns></returns>
        Task<string> UpdateToken(string studentCode, string mobileToken);

        /// <summary>
        /// 메인 페이지 - 모든 학기에 대한 과목 정보 얻기
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<string, List<LectureInfo>>> GetAllSemesterLectures();

        /// <summary>
        /// 강의 계획서 페이지 - 학과 정보 얻기
        /// </summary>
        /// <returns></returns>
        Task<List<DepartmentInfo>> GetAllDepartments(int year, int semester);

        /// <summary>
        /// 강의 계획서 페이지 - 강의 계획서 검색
        /// </summary>
        /// <param name="syllabusSearchInfo">강의 계획서 검색에 필요한 정보</param>
        /// <returns></returns>
        Task<List<SyllabusInfo>> SearchSyllabus(SyllabusSearchInfo syllabusSearchInfo);

        /// <summary>
        /// 수강 / 성적 조회 페이지 - 성적 정보 얻기
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<string, List<ScoreInfo>>> GetAllSemesterScores();
    }
}
