using System;
using System.Threading.Tasks;

namespace KLASMobileApp.Net
{
    public class RestManager
    {
        IRestService restService;

        public RestManager(IRestService service)
        {
            restService = service;
        }

        public Task<bool> LoginSecurity(string id, string pw)
        {
            return restService.LoginSecurity(id, pw);
        }

        public Task<string> GetSchdulInfo(string yearHakgi, string subject)
        {
            return restService.GetSchdulInfo(yearHakgi, subject);
        }
    }
}
