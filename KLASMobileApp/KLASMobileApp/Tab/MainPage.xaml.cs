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
        }
    }
}
