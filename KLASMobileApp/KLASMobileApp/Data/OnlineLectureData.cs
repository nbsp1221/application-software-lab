using System;
using Newtonsoft.Json;

namespace KLASMobileApp.Data
{
    public class OnlineLectureData
    {

        [JsonProperty("userId")]
        public string userId { get; set; }

        [JsonProperty("grcode")]
        public string grcode { get; set; }

        [JsonProperty("subj")]
        public string subj { get; set; }

        [JsonProperty("year")]
        public string year { get; set; }

        [JsonProperty("hakgi")]
        public string hakgi { get; set; }

        [JsonProperty("bunban")]
        public string bunban { get; set; }

        [JsonProperty("module")]
        public string module { get; set; }

        [JsonProperty("lesson")]
        public string lesson { get; set; }

        [JsonProperty("sdesc")]
        public string sdesc { get; set; }

        [JsonProperty("evltnSe")]
        public string evltnSe { get; set; }

        [JsonProperty("sbjt")]
        public string sbjt { get; set; }

        [JsonProperty("rcognTime")]
        public object rcognTime { get; set; }

        [JsonProperty("weeklyseq")]
        public int weeklyseq { get; set; }

        [JsonProperty("sdate")]
        public string sdate { get; set; }

        [JsonProperty("edate")]
        public string edate { get; set; }

        [JsonProperty("today")]
        public string today { get; set; }

        [JsonProperty("startDate")]
        public string startDate { get; set; }

        [JsonProperty("endDate")]
        public string endDate { get; set; }

        [JsonProperty("types")]
        public string types { get; set; }

        [JsonProperty("oid")]
        public string oid { get; set; }

        [JsonProperty("connYn")]
        public string connYn { get; set; }

        [JsonProperty("ispreview")]
        public string ispreview { get; set; }

        [JsonProperty("isonoff")]
        public string isonoff { get; set; }

        [JsonProperty("ptype")]
        public string ptype { get; set; }

        [JsonProperty("pcond1")]
        public object pcond1 { get; set; }

        [JsonProperty("ptime")]
        public string ptime { get; set; }

        [JsonProperty("pcond2")]
        public object pcond2 { get; set; }

        [JsonProperty("totalTime")]
        public string totalTime { get; set; }

        [JsonProperty("bunbanroom")]
        public object bunbanroom { get; set; }

        [JsonProperty("sdate2")]
        public object sdate2 { get; set; }

        [JsonProperty("edate2")]
        public object edate2 { get; set; }

        [JsonProperty("sdateY")]
        public string sdateY { get; set; }

        [JsonProperty("sdateH")]
        public string sdateH { get; set; }

        [JsonProperty("sdateM")]
        public string sdateM { get; set; }

        [JsonProperty("edateY")]
        public string edateY { get; set; }

        [JsonProperty("edateH")]
        public string edateH { get; set; }

        [JsonProperty("edateM")]
        public string edateM { get; set; }

        [JsonProperty("lrnPd")]
        public string lrnPd { get; set; }

        [JsonProperty("starting")]
        public string starting { get; set; }

        [JsonProperty("width")]
        public int width { get; set; }

        [JsonProperty("height")]
        public int height { get; set; }

        [JsonProperty("learnTime")]
        public string learnTime { get; set; }

        [JsonProperty("prog")]
        public int prog { get; set; }

        [JsonProperty("firstEdu")]
        public string firstEdu { get; set; }

        [JsonProperty("firstEnd")]
        public string firstEnd { get; set; }

        [JsonProperty("achivTime")]
        public object achivTime { get; set; }

        [JsonProperty("weekNo")]
        public int weekNo { get; set; }

        [JsonProperty("moduletitle")]
        public string moduletitle { get; set; }

        [JsonProperty("totRcognTime")]
        public int totRcognTime { get; set; }

        [JsonProperty("totAchivTime")]
        public int totAchivTime { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("ordseq")]
        public int? ordseq { get; set; }

        [JsonProperty("registDt")]
        public string registDt { get; set; }
    }
}
