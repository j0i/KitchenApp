﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using Windows.Globalization.DateTimeFormatting;

namespace KitchenApp.Models
{
    public class Orders : RealmObject
    {
        public string _id { get; set; }
        public IList<MenuItems> menuItems { get; }
        public bool send_to_kitchen { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string employee_id { get; set; }

        //soon will have a table number
        public int table_number { get; set; }
        public string time_completed {get; set;}
        public string table_number_string => "Table " + table_number;

        //Not received by the server but stored to give each order a unique time of arrival
        TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        public DateTime updatedAtDate => TimeZoneInfo.ConvertTimeFromUtc(DateTime.Parse(createdAt).ToUniversalTime(), cstZone);
        public string updatedAtString => updatedAtDate.ToString("t");
    }
}
