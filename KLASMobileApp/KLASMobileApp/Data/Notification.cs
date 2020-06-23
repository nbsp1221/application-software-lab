using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLASMobileApp.Data
{
    public class NotificationInfo
    {
        public string DuplicateCheck { get; set; }
        public string StudentCode { get; set; }
        public string NotificationTime { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }

        public NotificationInfo()
        {
            this.DuplicateCheck = "";
            this.StudentCode = "";
            this.NotificationTime = "";
            this.MessageTitle = "";
            this.MessageBody = "";
        }

        public NotificationInfo(string duplicateCheck, string studentCode, string notificationTime, string messageTitle, string messageBody)
        {
            this.DuplicateCheck = duplicateCheck;
            this.StudentCode = studentCode;
            this.NotificationTime = notificationTime;
            this.MessageTitle = messageTitle;
            this.MessageBody = messageBody;
        }

        public NotificationInfo(string duplicateCheck, string studentCode, DateTime notificationTime, string messageTitle, string messageBody)
        {
            this.DuplicateCheck = duplicateCheck;
            this.StudentCode = studentCode;
            this.NotificationTime = ConvertDateTime(notificationTime);
            this.MessageTitle = messageTitle;
            this.MessageBody = messageBody;
        }

        private string ConvertDateTime(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        private DateTime ConvertDateTime(string dateTime)
        {
            return DateTime.Parse(dateTime);
        }

        public string ToJsonValue()
        {
            return JsonConvert.SerializeObject(new
            {
                duplicateCheck = this.DuplicateCheck,
                studentCode = this.StudentCode,
                notificationTime = this.NotificationTime,
                messageTitle = this.MessageTitle,
                messageBody = this.MessageBody
            });
        }
    }
}
