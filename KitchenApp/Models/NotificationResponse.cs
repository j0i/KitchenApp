using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenApp.Models
{
    public class NotificationResponse : RealmObject
    {
        public string message { get; set; }
        public Notifications notifications { get; set; }
    }
}