using System;
using System.Collections.Generic;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace KLASMobileApp
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();

            string id = Preferences.Get(Constants.Constants.Pref_Key_User_ID, "");
            string pw = Preferences.Get(Constants.Constants.Pref_Key_User_PW, "");

            if (id.Length > 0 && pw.Length > 0)
            {
                check(id, pw);
            }
            else
            {
                Device.StartTimer(TimeSpan.FromSeconds(1.2), () =>
                {
                    // 호출할 메서드나 내용을 넣고
                    startLogin();

                    // 리턴을 해주는데 True 이면 계속 반복, False 이면 정지 한다.
                    return false;
                });
            }
        }

        private async void startLogin()
        {
            await Navigation.PushAsync(new LoginPage());
            this.Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
        }

        private async void check(string id, string pw)
        {
            if (await App.RestManager.LoginSecurity(id, pw))
            {
                await this.Navigation.PushAsync(new TabPage());
                this.Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            else
            {
                startLogin();
            }
        }
    }
}
