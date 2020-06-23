using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLASMobileApp.Data
{
    public class ScoreInfo
    {
        public string LectureName { get; set; }
        public string LectureType { get; set; }
        public string LectureCode { get; set; }
        public string DepartmentName { get; set; }
        public uint Credit { get; set; }
        public string Grade { get; set; }
        public bool IsRetake { get; set; }
        public string RetakeGrade { get; set; }

        public ScoreInfo(JToken jToken)
        {
            this.LectureName = jToken["gwamokKname"].ToString();
            this.LectureType = jToken["codeName1"].ToString();
            this.LectureCode = jToken["hakjungNo"].ToString();
            this.DepartmentName = jToken["hakgwa"].ToString();
            this.Credit = (uint)jToken["hakjumNum"];
            this.Grade = jToken["getGrade"].ToString();
            this.IsRetake = jToken["retakeOpt"].ToString() == "Y";
            this.RetakeGrade = jToken["retakeGetGrade"].ToString();
        }
    }
}
