using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetAPI_News.Models
{
    public class User
    {
        public string IdTelegram { get; set; }
        public bool NotificationState { get; set; }

        public User(string idTelegram, bool notificationState)
        {
            IdTelegram = idTelegram;
            NotificationState = notificationState;
        }

        public User()
        {
        }
    }
}