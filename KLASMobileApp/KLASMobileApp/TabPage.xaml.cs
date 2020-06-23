using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KLASMobileApp
{
   
    public partial class TabPage : TabbedPage
    {
        public TabPage()
        {
            InitializeComponent();

            updateToken();
        }

        async void updateToken()
        {
            string str = await App.RestManager.UpdateToken(Preferences.Get(Constants.Constants.Pref_Key_User_ID, ""), Preferences.Get(Constants.Constants.Pref_Key_FcmToken, ""));

            //string str2 = await App.RestManager.AddNotification(new Data.NotificationInfo
            //(
            //    Preferences.Get(Constants.Constants.Pref_Key_User_ID, ""), dt, "테스트 타이틀", "테스트 바디"
            //));

            notiProcessing();
        }

        async void notiProcessing()
        {
            var lectureMap = await App.RestManager.GetAllSemesterLectures();

            var lectureInfo = lectureMap["2020,1"];

            foreach (Data.LectureInfo info in lectureInfo)
            {
                GetOnlineLecture("2020,1", info.Code, info.Name);
            }

        }

        async private void GetOnlineLecture(string yearhakgi, string subCode, string subName)
        {
            List<Data.OnlineLectureData> datas = await App.RestManager.GetOnlineLectures("2020,1", subCode);

            int count = 0;
            int totalcount = 0;
            DateTime curDate = DateTime.Now;
            DateTime lastDate = DateTime.Now;
            foreach (Data.OnlineLectureData data in datas)
            {
                if (DateTime.Compare(curDate, Convert.ToDateTime(data.endDate)) < 0)
                {
                    if (data.ptype != null && data.prog != 100)
                    {
                        totalcount++;
                        if ((count == 0 && DateTime.Compare(lastDate, Convert.ToDateTime(data.endDate)) < 0) || (count != 0 && DateTime.Compare(lastDate, Convert.ToDateTime(data.endDate)) > 0))
                        {
                            count = 0;
                            lastDate = Convert.ToDateTime(data.endDate);
                        }
                        if (DateTime.Compare(lastDate, Convert.ToDateTime(data.endDate)) == 0)
                        {
                            count++;
                        }
                    }
                }
            }
            if( totalcount >0 ) {
                TimeSpan timeDiff = lastDate - curDate;

           

                var noti = new Data.NotificationInfo(
                    Preferences.Get(Constants.Constants.Pref_Key_User_ID, ""),
                    lastDate.AddDays(-1),
                    "강의[" + subName + "]",
                    count + "개의 강의가 마감 1일 전입니다."
                    );

                await App.RestManager.AddNotification(noti);


            }

            List<Data.HomeWorkData> homeworkdatas = await App.RestManager.GetHomeWorks("2020,1", subCode);


            count = 0;
            totalcount = 0;
            curDate = DateTime.Now;
            lastDate = DateTime.Now;

            foreach (Data.HomeWorkData homeWork in homeworkdatas)
            {
                if (DateTime.Compare(curDate, Convert.ToDateTime(homeWork.expiredate)) < 0)
                {
                    if (homeWork.submityn.Equals("N"))
                    {
                        totalcount++;
                        if ((count == 0 && DateTime.Compare(lastDate, Convert.ToDateTime(homeWork.expiredate)) < 0) || (count != 0 && DateTime.Compare(lastDate, Convert.ToDateTime(homeWork.expiredate)) > 0))
                        {
                            count = 0;
                            lastDate = Convert.ToDateTime(homeWork.expiredate);
                        }
                        if (DateTime.Compare(lastDate, Convert.ToDateTime(homeWork.expiredate)) == 0)
                        {
                            count++;
                        }
                    }
                }
            }
            if (totalcount > 0)
            {
                var noti = new Data.NotificationInfo(
                    Preferences.Get(Constants.Constants.Pref_Key_User_ID, ""),
                    lastDate.AddDays(-1),
                    "과제[" + subName + "]",
                    count + "개의 과제가 마감 1일 전입니다."
                    );

                await App.RestManager.AddNotification(noti);


            }
        }
    }
}
