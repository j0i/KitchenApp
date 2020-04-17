﻿using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenApp.Models
{
    public class Notifications : RealmObject
    {
        [PrimaryKey]
        public string _id { get; set; }
        public string employee_id { get; set; }
        public string sender { get; set; }
        public string notificationType { get; set; }
    }
}