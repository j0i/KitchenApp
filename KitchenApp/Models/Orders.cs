using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenApp.Models
{
    public class Orders
    {
        public string _id { get; set; }
        public IList<MenuItems> menuItems { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }
}
