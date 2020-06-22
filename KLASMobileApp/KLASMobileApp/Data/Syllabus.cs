using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLASMobileApp.Data
{
    public class DepartmentInfo
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }

        public DepartmentInfo(string code, string name, string subName)
        {
            this.Code = code;
            this.Name = name;
            this.SubName = subName;
        }
    }

    public class SyllabusSearchInfo
    {
        public uint Year { get; set; }
        public uint Semester { get; set; }
        public bool IsMyLecture { get; set; }
        public string LectureName { get; set; }
        public string ProfessorName { get; set; }
        public string DepartmentCode { get; set; }

        public SyllabusSearchInfo()
        {
            this.LectureName = "";
            this.ProfessorName = "";
            this.DepartmentCode = "";
        }
    }

    public class SyllabusInfo
    {
        public string LectureName { get; set; }
        public string LectureType { get; set; }
        public string ProfessorName { get; set; }
        public string ProfessorContact { get; set; }
        public string Summary { get; set; }
        public bool IsClosed { get; set; }
        public uint Credit { get; set; }
        public uint Time { get; set; }
        public string MajorCode { get; set; }
        public uint Grade { get; set; }
        public string LectureCode { get; set; }
        public string ClassNumber { get; set; }

        public SyllabusInfo(JToken jToken)
        {
            this.LectureName = jToken["gwamokKname"].ToString();
            this.LectureType = jToken["codeName1"].ToString();
            this.ProfessorName = jToken["memberName"].ToString();
            this.ProfessorContact = jToken["telNo"].ToString();
            this.Summary = jToken["summary"].ToString();
            this.IsClosed = jToken["closeOpt"] != null;
            this.Credit = (uint)jToken["hakjumNum"];
            this.Time = (uint)jToken["sisuNum"];
            this.MajorCode = jToken["openMajorCode"].ToString();
            this.Grade = (uint)jToken["openGrade"];
            this.LectureCode = jToken["openGwamokNo"].ToString();
            this.ClassNumber = jToken["bunbanNo"].ToString();
        }
    }
}
