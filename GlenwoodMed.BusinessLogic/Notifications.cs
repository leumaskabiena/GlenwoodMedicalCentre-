using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GlenwoodMed.BusinessLogic
{
    public class NotificationsO
    {
        private const string DictionaryName = "NOTIFICATIONS";
        private IList<NotificationOB> _notifications;

        public NotificationsO(TempDataDictionary tempDataDictionary)
        {
            if (!tempDataDictionary.ContainsKey(DictionaryName))
            {
                tempDataDictionary[DictionaryName] = new List<NotificationOB>();
            }
            _notifications = tempDataDictionary[DictionaryName] as IList<NotificationOB>;
        }

        public IEnumerable<NotificationOB> Current
        {
            get { return _notifications; }
        }

        public void Add(Status status, string message)
        {
            _notifications.Add(new NotificationOB { Status = status, Message = message });
        }
    }

    public class NotificationOB
    {
        public Status Status { get; set; }

        public string Message { get; set; }
    }
    public enum Status
    {
        Error, Warning, Success
    }


}
