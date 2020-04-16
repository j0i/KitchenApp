using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using KitchenApp.Models;

namespace KitchenApp.Models.Requests
{
    public class PutToPreparedRequest : ServiceRequest 
    {
        string orderID;
        public override string Url => "https://dijkstras-steakhouse-restapi.herokuapp.com/orders/" + orderID;
        public override HttpMethod Method => HttpMethod.Put;
        public override Dictionary<string, string> Headers => null;
        public List<UpdaterObject> Body;

        PutToPreparedRequest(Orders order )
        {

        }
        //request body content object
        public class UpdaterObject
        {
            //what the server expects
            public string propName = "menuItems";
            public IList<SerializableOrderItem> value = new List<SerializableOrderItem>();

        }
        public class SerializableOrderItem
        {
            public List<MenuItems> menuItems;
            public bool prepared;
            public bool paid;
            public string special_instruct;
            public string name;
            public string price;
            public string _id;

            public SerializableOrderItem(Orders order)
            {
                _id = order._id;
                menuItems = order.menuItems.ToList();

            }
        }
    }
}
