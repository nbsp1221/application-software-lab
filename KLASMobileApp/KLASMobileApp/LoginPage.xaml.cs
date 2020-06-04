using System.Net;
using Xamarin.Forms;

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
