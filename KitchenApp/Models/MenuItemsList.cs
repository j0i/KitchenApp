using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenApp.Models
{
    //Server returns a list of MenuItems
    public class MenuItemsList
    {
        public IList<MenuItems> menuItems { get; }
    }
}
