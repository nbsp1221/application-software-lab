using System;
using System.Collections.Generic;
using KLASMobileApp.DetailPages;
using Xamarin.Forms;

namespace KLASMobileApp.Tab
{
    public partial class ToolPage : ContentPage
    {
        private Dictionary<string, List<Data.LectureInfo>> lectureMap;

        public ToolPage()
        {
            InitializeComponent();

            GetLectureList();
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if (lectureMap != null && lectureMap["2020,1"] !=null )
            {   
                await Navigation.PushModalAsync(new CurProgPage(lectureMap["2020,1"],"2020,1"));
            }
        }

        async void GetLectureList()
        {
            lectureMap = await App.RestManager.GetAllSemesterLectures();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (App.load_require)
            {
                var tabPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 1] as TabbedPage;

                tabPage.CurrentPage = tabPage.Children[0];
            }
        }
    }
}
