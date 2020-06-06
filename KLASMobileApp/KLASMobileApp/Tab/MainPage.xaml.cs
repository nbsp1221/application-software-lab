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
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            label.Text = "테스트 api 호출 : "+ await App.RestManager.GetSchdulInfo("2020,1", "U202018485H030023");

            LecturesBean str = await App.RestManager.GetStdInfo();

            
            Console.WriteLine(str);
        }
    }
}
