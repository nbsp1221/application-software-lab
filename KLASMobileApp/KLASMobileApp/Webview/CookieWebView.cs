using System;
using System.Net;
using Xamarin.Forms;

namespace KLASMobileApp.Webview
{
    public class CookieWebView : WebView
    {
        public static readonly BindableProperty CookiesProperty = BindableProperty.Create(
    propertyName: "Cookies",
        returnType: typeof(CookieContainer),
        declaringType: typeof(CookieWebView),
      defaultValue: default(string));

        public CookieContainer Cookies
        {
            get { return (CookieContainer)GetValue(CookiesProperty); }
            set { SetValue(CookiesProperty, value); }
        }

        public CookieWebView()
        {
            Cookies = new CookieContainer();
        }
    }
}
