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

            List<DepartmentInfo> allDepartments = await App.RestManager.GetAllDepartments(2020, 1);

            foreach (var v in allDepartments)
            {
                Debug.Print("{0}\t{1}\t{2}", v.Code, v.Name, v.SubName);
            }

            


            //label.Text = "테스트 api 호출 : "+ await App.RestManager.GetSchdulInfo("2020,1", "U202018485H030023");
            //LecturesBean str = await App.RestManager.GetStdInfo();
            //System.Diagnostics.Debug.WriteLine("Text");
        }
    }
}
