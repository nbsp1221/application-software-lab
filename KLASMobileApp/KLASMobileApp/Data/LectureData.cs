using System;
using Newtonsoft.Json;

namespace KLASMobileApp.Data
{
    public class LectureData
    {

        [JsonProperty("bunban")]
        public string bunban { get; set; }

        [JsonProperty("codenmord")]
        public string codenmord { get; set; }

        [JsonProperty("grcode")]
        public string grcode { get; set; }

        [JsonProperty("hakgi")]
        public string hakgi { get; set; }

        [JsonProperty("hakjungno")]
        public string hakjungno { get; set; }

        [JsonProperty("isblended")]
        public string isblended { get; set; }

        [JsonProperty("iselearn")]
        public string iselearn { get; set; }

        [JsonProperty("isonoff")]
        public object isonoff { get; set; }

        [JsonProperty("lctrumSchdulInfo")]
        public string lctrumSchdulInfo { get; set; }

        [JsonProperty("lctrumSchdulTimeList")]
        public object lctrumSchdulTimeList { get; set; }

        [JsonProperty("newicon")]
        public string newicon { get; set; }

        [JsonProperty("openOrganCodeNm")]
        public string openOrganCodeNm { get; set; }

        [JsonProperty("profNm")]
        public string profNm { get; set; }

        [JsonProperty("subj")]
        public string subj { get; set; }

        [JsonProperty("subjLabel")]
        public string subjLabel { get; set; }

        [JsonProperty("subjNm")]
        public string subjNm { get; set; }

        [JsonProperty("year")]
        public string year { get; set; }

        [JsonProperty("yearhakgi")]
        public string yearhakgi { get; set; }
    }
}
