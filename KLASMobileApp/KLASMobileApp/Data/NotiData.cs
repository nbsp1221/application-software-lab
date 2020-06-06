using System;
using Newtonsoft.Json;

namespace KLASMobileApp.Data
{
    public class NotiData
    {

        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("typeNm")]
        public string typeNm { get; set; }

        [JsonProperty("subjNm")]
        public string subjNm { get; set; }

        [JsonProperty("grcode")]
        public string grcode { get; set; }

        [JsonProperty("year")]
        public string year { get; set; }

        [JsonProperty("hakgi")]
        public string hakgi { get; set; }

        [JsonProperty("subj")]
        public string subj { get; set; }

        [JsonProperty("bunban")]
        public string bunban { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("registDt")]
        public DateTime registDt { get; set; }

        [JsonProperty("param")]
        public string param { get; set; }
    }
}
