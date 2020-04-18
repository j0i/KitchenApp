using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KitchenApp.Models.Requests
{
    class PutToPreparedRequest : ServiceRequest
    {
        string orderID;
        //the endpoint we are trying to hit
        public override string Url => "https://dijkstras-steakhouse-restapi.herokuapp.com/orders/" + orderID;
        //the type of request
        public override HttpMethod Method => HttpMethod.Put;
        //headers if we ever need them
        public override Dictionary<string, string> Headers => null;

        public List<UpdaterObject> Body;

        // Constructor containing menu items (order items) that need to be updated
        PutToPreparedRequest(string order_ID, List<MenuItems> toUpdate)
        {
            orderID = order_ID;

            UpdaterObject updaterObject = new UpdaterObject();
            foreach (MenuItems m in toUpdate)
                updaterObject.value.Add(new SerializableOrderItem(orderID, m));

            Body = new List<UpdaterObject>();
            Body.Add(updaterObject);
        }

        // Request body content object
        public class UpdaterObject
        {
            public string propName = "menuItems";
            public IList<SerializableOrderItem> value = new List<SerializableOrderItem>();
        }

        // Objects to contain just the information needed to update the order. 
        // Since OrderItems extend RealmObject, they contain a bunch of extra stuff we don't need
        public class SerializableOrderItem
        {
            public IList<string> ingredients;

            public bool prepared;

            public bool paid;

            public string special_instruct;

            public string name;

            public double price;

            public string _id;

            public SerializableOrderItem(string o_id, MenuItems m)
            {
                _id = o_id;

                ingredients = m.ingredients;

                prepared = !m.prepared;

                paid = m.paid;

                price = m.price;

                name = m.name;

                special_instruct = m.special_instruct;
            }
        }

        public static async Task<bool> SendPutToPreparedRequest(string order_ID, List<MenuItems> toUpdate)
        {
            //make a new request object
            var serviceRequest = new PutToPreparedRequest(order_ID, toUpdate);
            //get a response
            var response = await ServiceRequestHandler.MakeServiceCall<DeleteResponse>(serviceRequest, serviceRequest.Body);

            if (response == null)
            {
                //call failed
                return false;
            }
            else
            {
                //call succeeded
                return true;
            }
        }
    }
}
