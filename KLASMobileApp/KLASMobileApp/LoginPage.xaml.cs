using System.Net;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace KLASMobileApp
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
        }
         

        async void startLogin()
        {
            
            if(await App.RestManager.LoginSecurity(idEntry.Text, pwEntry.Text))
            {
                Preferences.Set(Constants.Constants.Pref_Key_User_ID,idEntry.Text);
                Preferences.Set(Constants.Constants.Pref_Key_User_PW, pwEntry.Text);

                await this.Navigation.PushAsync(new TabPage());
                this.Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            else
            {
                await DisplayAlert("", "로그인 실패", "확인");
            }
        }

        void loginBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            startLogin();
        }

    }
}
