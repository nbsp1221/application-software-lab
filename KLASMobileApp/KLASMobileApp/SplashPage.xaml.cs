using System;
using System.Collections.Generic;
using System.Threading;
using Xamarin.Forms;

namespace KLASMobileApp
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1.2), () =>
            {
                // 호출할 메서드나 내용을 넣고
                startLogin();

                // 리턴을 해주는데 True 이면 계속 반복, False 이면 정지 한다.
                return false;
            });
        }

        private async void startLogin()
        {
            await Navigation.PushAsync(new LoginPage());
            this.Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
        }
    }
}
