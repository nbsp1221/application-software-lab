using System;
using Android.Content;
using Android.Graphics;
using Android.Webkit;
using KLASMobileApp.Droid;
using KLASMobileApp.Webview;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(CookieWebView), typeof(CookieWebViewRenderer))]
namespace KLASMobileApp.Droid
{

    public class CookieWebViewRenderer : Xamarin.Forms.Platform.Android.WebViewRenderer
    {
        public CookieWebViewRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            if (e.NewElement != null)
            {
                var cookieManager = CookieManager.Instance;
                cookieManager.SetAcceptCookie(true);
                //cookieManager.RemoveAllCookie();
                var cookies = UserInfo.CookieContainer.GetCookies(new System.Uri("https://klas.kw.ac.kr"));
                for (var i = 0; i < cookies.Count; i++)
                {
                    string cookieValue = cookies[i].Value;
                    string cookieDomain = cookies[i].Domain;
                    string cookieName = cookies[i].Name;
                    cookieManager.SetCookie(cookieDomain, cookieName + "=" + cookieValue);
                }

            }

            base.OnElementChanged(e);

            Control.SetWebViewClient(new CookieWebViewClient(CookieWebView));

            //if (e.NewElement != null)
            //{
            //    var cookieManager = CookieManager.Instance;
            //    cookieManager.SetAcceptCookie(true);
            //    cookieManager.RemoveAllCookie();
            //    var cookies = CookieWebView.Cookies.GetCookies(new System.Uri("https://klas.kw.ac.kr"));
            //    for (var i = 0; i < cookies.Count; i++)
            //    {
            //        string cookieValue = cookies[i].Value;
            //        string cookieDomain = cookies[i].Domain;
            //        string cookieName = cookies[i].Name;
            //        cookieManager.SetCookie(cookieDomain, cookieName + "=" + cookieValue);
            //    }
            //}
        }
        public CookieWebView CookieWebView
        {
            get { return Element as CookieWebView; }
        }

    }

    internal class CookieWebViewClient : WebViewClient
    {
        private readonly CookieWebView _cookieWebView;
        internal CookieWebViewClient(CookieWebView cookieWebView)
        {
            _cookieWebView = cookieWebView;
        }

        public override void OnPageStarted(global::Android.Webkit.WebView view, string url, Bitmap favicon)
        {

            base.OnPageStarted(view, url, favicon);


        }



        public override void OnPageFinished(global::Android.Webkit.WebView view, string url)
        {

        }

        public override bool ShouldOverrideUrlLoading(Android.Webkit.WebView view, IWebResourceRequest request)
        {
            if (request.IsRedirect)
            {
                view.LoadUrl(view.Url);
                return true;
            }


            return false;
        }
    }
}
