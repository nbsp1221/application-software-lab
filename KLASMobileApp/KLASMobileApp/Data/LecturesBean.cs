using System;
using System.Collections.Generic;

namespace KLASMobileApp.Data
{
    public class LecturesBean
    {
        public List<LectureData> lectureList { get; set; }

        public List<TimeTableData> timeTableData { get; set; }

        public List<NotiData> notiList { get; set; }

        public ProfessorData professorData { get; set; }
    }
}
