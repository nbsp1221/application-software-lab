using System;
using Newtonsoft.Json;

namespace KLASMobileApp.Data
{
    public class TimeTableData
    {

        [JsonProperty("wtTime")]
        public int wtTime { get; set; }

        [JsonProperty("wtHasSchedule")]
        public string wtHasSchedule { get; set; }

        [JsonProperty("wtSpan_2")]
        public int wtSpan_2 { get; set; }

        [JsonProperty("wtYearhakgi_2")]
        public string wtYearhakgi_2 { get; set; }

        [JsonProperty("wtSubj_2")]
        public string wtSubj_2 { get; set; }

        [JsonProperty("wtSubjNm_2")]
        public string wtSubjNm_2 { get; set; }

        [JsonProperty("wtLocHname_2")]
        public string wtLocHname_2 { get; set; }

        [JsonProperty("wtProfNm_2")]
        public string wtProfNm_2 { get; set; }

        [JsonProperty("wtSubjPrintSeq_2")]
        public int wtSubjPrintSeq_2 { get; set; }

        [JsonProperty("wtSpan_3")]
        public int wtSpan_3 { get; set; }

        [JsonProperty("wtYearhakgi_3")]
        public string wtYearhakgi_3 { get; set; }

        [JsonProperty("wtSubj_3")]
        public string wtSubj_3 { get; set; }

        [JsonProperty("wtSubjNm_3")]
        public string wtSubjNm_3 { get; set; }

        [JsonProperty("wtLocHname_3")]
        public string wtLocHname_3 { get; set; }

        [JsonProperty("wtProfNm_3")]
        public string wtProfNm_3 { get; set; }

        [JsonProperty("wtSubjPrintSeq_3")]
        public int wtSubjPrintSeq_3 { get; set; }
    }
}
