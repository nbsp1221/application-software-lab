using System;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace KLASMobileApp.Constants
{
    public class Constants
    {
        public static string Url_LoginSecurity = "https://klas.kw.ac.kr/usr/cmn/login/LoginSecurity.do";
        public static string Url_LoginConfirm = "https://klas.kw.ac.kr/usr/cmn/login/LoginConfirm.do";

        public static string Url_LctrumSchdulInfo = "https://klas.kw.ac.kr/std/cmn/frame/LctrumSchdulInfo.do";
        public static string Url_StdHome = "https://klas.kw.ac.kr/std/cmn/frame/StdHome.do";



        public static string Pref_Key_Alarm = "alarm";
        public static string Pref_Key_FcmToken = "fcmToken";
        public static string Pref_Key_User_ID = "user_id";
        public static string Pref_Key_User_PW = "user_pw";



        /// <summary>
        /// 알림 서버 - 토큰 추가 및 업데이트
        /// </summary>
        public static string URL_UpdateToken = "https://retn0.kr/klas-helper/token-update.php";

        /// <summary>
        /// 알림 서버 - 알림 추가
        /// </summary>
        public static string URL_AddNotification = "https://retn0.kr/klas-helper/notification-add.php";

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

        /// <summary>
        /// 온라인 강의 컨텐츠 검색 - 온라인 강의 리스트
        /// </summary>
        public static string URL_OnlineLectures= "https://klas.kw.ac.kr/std/lis/evltn/SelectOnlineCntntsStdList.do";

        /// <summary>
        /// 과제 정보 얻기
        /// </summary>
        public static string URL_HomweWorks = "https://klas.kw.ac.kr/std/lis/evltn/TaskStdList.do";
        /// 수강 / 성적 조회 페이지 - 성적 정보 얻기
        /// </summary>
        public static string URL_AllSemesterScores = "https://klas.kw.ac.kr/std/cps/inqire/AtnlcScreSungjukInfo.do";
    }
}
