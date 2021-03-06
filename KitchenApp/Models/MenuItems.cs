﻿using KitchenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace KitchenApp.Models
{
    //Individual properties to be stored in MenuItemsList
    public class MenuItems : RealmObject
    {
        public IList<string> ingredients { get; }
        public string _id { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string nutrition { get; set; }
        public string item_type { get; set; }
        public string category { get; set; }
        public bool paid { get; set; }
        public string time_completed {get; set;}

        //From here down, extra stuff that Orders returns
        public bool prepared { get; set; }
        public string special_instruct { get; set; }
        public string specialInstruction
        {
            get => special_instruct;
            set
            {
                if(String.IsNullOrEmpty(special_instruct))
                {
                    special_instruct = "";
                }
                else
                {
                    special_instruct = "- " + special_instruct;
                }
            }
        }

    }
}
