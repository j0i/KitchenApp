using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace KitchenApp.Models
{
    //Server returns MenuItemsList which contains within it a list of ingredients
    public class IngredientsList : RealmObject
    {
        public IList<Ingredients> doc { get; }
    }
}
