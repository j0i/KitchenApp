using KitchenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenApp
{
    //Individual properties to be stored in MenuItemsList
    public class MenuItems
    {
        public IList<Ingredients> ingredients { get; set; }
        public string _id { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public string nutrition { get; set; }
        public string item_type { get; set; }
        public string category { get; set; }
        public bool paid { get; set; }
    }
}
