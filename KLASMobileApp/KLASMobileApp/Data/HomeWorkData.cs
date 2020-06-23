using System;
using Newtonsoft.Json;

namespace KLASMobileApp.Data
{
    public class HomeWorkData
    {

        [JsonProperty("ordseq")]
        public int ordseq { get; set; }

        [JsonProperty("weeklyseq")]
        public int weeklyseq { get; set; }

        [JsonProperty("weeklysubseq")]
        public int weeklysubseq { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("startdate")]
        public string startdate { get; set; }

        [JsonProperty("expiredate")]
        public string expiredate { get; set; }

        [JsonProperty("score")]
        public object score { get; set; }

        [JsonProperty("isopen")]
        public string isopen { get; set; }

        [JsonProperty("restartdate")]
        public object restartdate { get; set; }

        [JsonProperty("reexpiredate")]
        public object reexpiredate { get; set; }

        [JsonProperty("weight")]
        public object weight { get; set; }

        [JsonProperty("indate")]
        public string indate { get; set; }

        [JsonProperty("adddate")]
        public string adddate { get; set; }

        [JsonProperty("submityn")]
        public string submityn { get; set; }
    }
}
