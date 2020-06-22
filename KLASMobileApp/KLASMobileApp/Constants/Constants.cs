﻿using System;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace KLASMobileApp.Constants
{
    public class Constants
    {
        public static string Url_LoginSecurity = "https://klas.kw.ac.kr/usr/cmn/login/LoginSecurity.do";
        public static string Url_LoginConfirm = "https://klas.kw.ac.kr/usr/cmn/login/LoginConfirm.do";

        public static string Url_LctrumSchdulInfo = "https://klas.kw.ac.kr/std/cmn/frame/LctrumSchdulInfo.do";
        public static string Url_StdHome = "https://klas.kw.ac.kr/std/cmn/frame/StdHome.do";



        /// <summary>
        /// 메인 페이지 - 모든 학기에 대한 과목 정보 얻기
        /// </summary>
        public static string URL_AllSemesterLectures = "https://klas.kw.ac.kr/std/cmn/frame/YearhakgiAtnlcSbjectList.do";

        /// <summary>
        /// 강의 계획서 페이지 - 학과 정보 얻기
        /// </summary>
        public static string URL_AllDepartments = "https://klas.kw.ac.kr/std/cps/atnlc/CmmnHakgwaList.do";

        /// <summary>
        /// 강의 계획서 페이지 - 강의 계획서 검색
        /// </summary>
        public static string URL_SearchSyllabus = "https://klas.kw.ac.kr/std/cps/atnlc/LectrePlanStdList.do";
    }
}
