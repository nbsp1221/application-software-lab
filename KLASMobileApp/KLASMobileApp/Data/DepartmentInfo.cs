using System;
using System.Collections.Generic;
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
}
