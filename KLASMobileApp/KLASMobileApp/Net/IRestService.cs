﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using KLASMobileApp.Data;

namespace KLASMobileApp.Net
{
    public interface IRestService
    {
        Task<IEnumerable<Cookie>> getCookies();

        Task<bool> LoginSecurity(string id, string pw);
        
        Task<String> GetSchdulInfo(string yearHakgi, string subject);

        Task<LecturesBean> GetStdInfo();



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


        Task<List<OnlineLectureData>> GetOnlineLectures(string selectYearhakgi, string selectSubj);
        Task<List<HomeWorkData>> GetHomeWorks(string selectYearhakgi, string selectSubj);
        
    }
}
