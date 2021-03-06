﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KLASMobileApp.Tab
{
    public partial class AlarmPage : ContentPage
    {

        private ObservableCollection<Alarm> alarms = new ObservableCollection<Alarm>();

        public AlarmPage()
        {
            InitializeComponent();

            BindingContext = new AlarmVM { Alarms = alarms };

            
            //listView.IsVisible =true;
            //label.IsVisible = false;
            //alarms.Add(new Alarm { Title = "과제[운영체제]", Des1 = "테스트과제", Des2 = "06/26 17:30" });
            //alarms.Add(new Alarm { Title = "과제[운영체제]", Des1 = "테스트과제", Des2 = "06/26 17:30" });
            //alarms.Add(new Alarm { Title = "과제[운영체제]", Des1 = "테스트과제", Des2 = "06/26 17:30" });
            //alarms.Add(new Alarm { Title = "과제[운영체제]", Des1 = "테스트과제", Des2 = "06/26 17:30" });
            //alarms.Add(new Alarm { Title = "과제[운영체제]", Des1 = "테스트과제", Des2 = "06/26 17:30" });
            //alarms.Add(new Alarm { Title = "과제[운영체제]", Des1 = "테스트과제", Des2 = "06/26 17:30" });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            alarms.Clear();
            var alarm = Preferences.Get(Constants.Constants.Pref_Key_Alarm, "");
            if (alarm.Length > 0)
            {
                var list = JsonConvert.DeserializeObject<List<Data.AlarmData>>(alarm);

                list.Reverse();
                foreach (Data.AlarmData data in list)
                {
                    alarms.Add(new Alarm { Title = data.title, Des1 = data.body, Des2 = data.time });
                }

            }
            else
            {
                listView.IsVisible = false;
                label.IsVisible = true;
            }
        }

        void listView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
        }
    }

    class Alarm
    {
        public string Title { get; set; }
        public string Des1 { get; set; }
        public string Des2 { get; set; }
        public string Code { get; set; }
        public string Hakgi { get; set; }
    }

    class AlarmVM
    {
        public ObservableCollection<Alarm> Alarms { get; set; }
    }
}
