using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Android.Webkit;
using KLASMobileApp.Data;
using KLASMobileApp.Net;
using Xamarin.Forms;

namespace KLASMobileApp.Tab
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            SyllabusSearchInfo syllabusSearchInfo = new SyllabusSearchInfo();
            syllabusSearchInfo.Year = 2020;
            syllabusSearchInfo.Semester = 1;
            syllabusSearchInfo.IsMyLecture = true;

            List<SyllabusInfo> syllabusInfos = await App.RestManager.SearchSyllabus(syllabusSearchInfo);

            foreach (var v in syllabusInfos)
            {
                Debug.Print("{0}\t{1}\t{2}", v.LectureName, v.LectureType, v.ProfessorName);
            }
            if (App.load_require)
            {
                if (App.curUrl.Equals("https://klas.kw.ac.kr/std/cmn/frame/Frame.do"))
                    webView.Source = App.loadUrl;
                else
                    webView.Source = App.loadUrl2;
                App.load_require = false;
            }

        }

        protected override bool OnBackButtonPressed()
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
                return true;
            }
            else
            {
                webView.GoBack();
                return true;
            }
        }

        void webView_Navigating(System.Object sender, Xamarin.Forms.WebNavigatingEventArgs e)
        {
            App.curUrl = e.Url;
        }
    }

    class Exam
    {
        public string Title { get; set; }
        public string Des1 { get; set; }
        public string Des2 { get; set; }
    }

    class ExamVM
    {
        public List<Exam> Exams { get; set; }
        public string Header { get { return "수강 과목 현황"; } }
    }
}
