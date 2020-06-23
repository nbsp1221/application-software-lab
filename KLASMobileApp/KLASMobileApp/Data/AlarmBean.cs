using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KLASMobileApp.Data
{
    public class AlarmBean
    {
        List<AlarmData> list { get; set; }

        public AlarmBean(List<AlarmData> list)
        {
            this.list = list;
        }


        public string ToJsonValue()
        {
            return JsonConvert.SerializeObject(list);
        }
    }
}
