using System;
using System.Threading.Tasks;

namespace KLASMobileApp.Net
{
    public interface IRestService
    {
        Task<bool> LoginSecurity(string id, string pw);

        Task<String> GetSchdulInfo(string yearHakgi, string subject);
    }
}
