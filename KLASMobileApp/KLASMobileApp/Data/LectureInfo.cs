using System;
using System.Collections.Generic;
using System.Text;

namespace KLASMobileApp.Data
{
    public class LectureInfo
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }

        public LectureInfo(string name, string label, string code)
        {
            this.Name = name;
            this.Label = label;
            this.Code = code;
        }
    }
}
