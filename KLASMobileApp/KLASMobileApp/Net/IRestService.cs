using System;
using System.Threading.Tasks;
using KLASMobileApp.Data;

namespace KLASMobileApp.Net
{
    public interface IRestService
    {
        void getCookies();

        Task<bool> LoginSecurity(string id, string pw);

        Task<String> GetSchdulInfo(string yearHakgi, string subject);

        Task<LecturesBean> GetStdInfo();        
    }
}
