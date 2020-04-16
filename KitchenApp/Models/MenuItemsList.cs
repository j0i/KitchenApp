using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace KitchenApp.Models
{
    //Server returns a list of MenuItems
    public class MenuItemsList : RealmObject
    {
        public IList<MenuItems> menuItems { get; }
    }
}
