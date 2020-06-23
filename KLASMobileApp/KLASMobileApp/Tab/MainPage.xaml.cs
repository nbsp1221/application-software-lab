using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
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

            var exams = new List<Exam> {
                new Exam { Title="과목1", Des1="n개의 강의중 n개가 n일후 마감입니다.", Des2 = "n개의 과제중 n개가 n일후 마감입니다."},
                new Exam { Title="과목1", Des1="n개의 강의중 n개가 n일후 마감입니다.", Des2 = "n개의 과제중 n개가 n일후 마감입니다."},
                new Exam { Title="과목1", Des1="n개의 강의중 n개가 n일후 마감입니다.", Des2 = "n개의 과제중 n개가 n일후 마감입니다."},
                new Exam { Title="과목1", Des1="n개의 강의중 n개가 n일후 마감입니다.", Des2 = "n개의 과제중 n개가 n일후 마감입니다."},
                new Exam { Title="과목1", Des1="n개의 강의중 n개가 n일후 마감입니다.", Des2 = "n개의 과제중 n개가 n일후 마감입니다."},
                new Exam { Title="과목1", Des1="n개의 강의중 n개가 n일후 마감입니다.", Des2 = "n개의 과제중 n개가 n일후 마감입니다."},
                new Exam { Title="과목1", Des1="n개의 강의중 n개가 n일후 마감입니다.", Des2 = "n개의 과제중 n개가 n일후 마감입니다."},
                new Exam { Title="과목1", Des1="n개의 강의중 n개가 n일후 마감입니다.", Des2 = "n개의 과제중 n개가 n일후 마감입니다."}
            };

            BindingContext = new ExamVM { Exams = exams };

            webView.Source = "https://klas.kw.ac.kr/std/cmn/frame/Frame.do";
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            SyllabusSearchInfo syllabusSearchInfo = new SyllabusSearchInfo();
            syllabusSearchInfo.Year = 2020;
            syllabusSearchInfo.Semester = 1;
            syllabusSearchInfo.IsMyLecture = true;

            App.RestManager.getCookies();

            List<SyllabusInfo> syllabusInfos = await App.RestManager.SearchSyllabus(syllabusSearchInfo);

            foreach (var v in syllabusInfos)
            {
                Debug.Print("{0}\t{1}\t{2}", v.LectureName, v.LectureType, v.ProfessorName);
            }
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
