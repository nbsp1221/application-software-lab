using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace KLASMobileApp.DetailPages
{
    public partial class CurProgPage : ContentPage
    {
        private ObservableCollection<Exam> exams = new ObservableCollection<Exam>();

        public CurProgPage()
        {
            InitializeComponent();

            //foreach (Data.LectureInfo info in lectureInfos)
            //{
            //    GetOnlineLecture(yearhakgi, info.Code, info.Name);
            //}

            BindingContext = new ExamVM { Exams = exams };
            GetLectureList();
        }

        async void GetLectureList()
        {
            var lectureMap = await App.RestManager.GetAllSemesterLectures();

            foreach (Data.LectureInfo info in lectureMap["2020,1"])
            {
                GetOnlineLecture("2020,1", info.Code, info.Name);
            }
        }

        void listView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var exam = e.SelectedItem as Exam;

            //DisplayAlert("click", exam.Des1, "OK");


            App.loadUrl = "javascript:appModule.goLctrum('" + exam.Hakgi + "', '" + exam.Code + "')";
            App.loadUrl2 = "javascript:appSelectSubj.getYearhakgiAtnlcSbjectList('" + exam.Hakgi + "', '" + exam.Code + "')";
            App.load_require = true;

            var tabPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 1] as TabbedPage;

            tabPage.CurrentPage = tabPage.Children[0];

        }

        async private void GetOnlineLecture(string yearhakgi, string subCode, string subName)
        {
            var exam = new Exam();
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
            if (totalcount == 0)
            {
                exam.Title = subName;
                exam.Des1 = "남아있는 강의가 없습니다!";
                exam.Des2 = "";
                exam.Des1_Color = "#02ab32";


            }
            else
            {
                TimeSpan timeDiff = lastDate - curDate;

                exam.Title = subName;
                if (timeDiff.Days == 0)
                {
                    exam.Des1 = totalcount + "개의 강의중 " + count + "개가 " + timeDiff.Hours + "시간 후 마감입니니다.";
                    exam.Des1_Color = "#fc0505";
                }
                else
                {
                    exam.Des1 = totalcount + "개의 강의중 " + count + "개가 " + timeDiff.Days + "일 후 마감입니니다.";
                    exam.Des1_Color = "#000000";
                }

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
            if (totalcount == 0)
            {

                exam.Des2 = "남아있는 과제가 없습니다!";
                exam.Des2_Color = "#02ab32";
            }
            else
            {
                TimeSpan timeDiff = lastDate - curDate;

                if (timeDiff.Days == 0)
                {
                    exam.Des2 = totalcount + "개의 과제중 " + count + "개가 " + timeDiff.Hours + "시간 후 마감입니니다.";
                    exam.Des2_Color = "#fc0505";
                }
                else
                {
                    exam.Des2 = totalcount + "개의 과제중 " + count + "개가 " + timeDiff.Days + "일 후 마감입니니다.";
                    exam.Des2_Color = "#000000";
                }

            }

            exam.Hakgi = yearhakgi;
            exam.Code = subCode;
            exams.Add(exam);
        }
    }

    class Exam
    {
        public string Title { get; set; }
        public string Des1 { get; set; }
        public string Des2 { get; set; }
        public string Des1_Color { get; set; }
        public string Des2_Color { get; set; }
        public string Code { get; set; }
        public string Hakgi { get; set; }
    }

    class ExamVM
    {
        public ObservableCollection<Exam> Exams { get; set; }
    }
}
