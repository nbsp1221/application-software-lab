using System;
using System.Collections.Generic;
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


            WebView a = new WebView();
            
           
           


        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //label.Text = "테스트 api 호출 : "+ await App.RestManager.GetSchdulInfo("2020,1", "U202018485H030023");

            LecturesBean str = await App.RestManager.GetStdInfo();

            App.RestManager.getCookies();



            Console.WriteLine(str);
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
