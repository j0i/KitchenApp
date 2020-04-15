using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace KitchenApp.Models
{
    public class Orders : RealmObject
    {
        public string _id { get; set; }
        public IList<MenuItems> menuItems { get; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string employee_id { get; set; }
        //soon will have a table number
        public int table_number { get; }
    }
}
