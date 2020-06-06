using System;
using Newtonsoft.Json;

namespace KLASMobileApp.Data
{
    public class ProfessorData
    {

        [JsonProperty("kname")]
        public string kname { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("labLocation")]
        public string labLocation { get; set; }

        [JsonProperty("homepage")]
        public string homepage { get; set; }

        [JsonProperty("counselTime")]
        public object counselTime { get; set; }

        [JsonProperty("telNum")]
        public string telNum { get; set; }
    }

}
