using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;

namespace KitchenApp.Models.Requests
{
    public class GetOrdersRequest : ServiceRequest 
    {
        public override string Url => "https://dijkstras-steakhouse-restapi.herokuapp.com/orders";
        public override HttpMethod Method => HttpMethod.Get;
        public override Dictionary<string, string> Headers => null;

        public async static Task<bool> SendGetOrdersRequest()
        {
            GetOrdersRequest getOrdersRequest = new GetOrdersRequest();
            var response = await ServiceRequestHandler.MakeServiceCall<OrdersList>(getOrdersRequest);

            if(response.Orders != null)
            {
                // Will filter out any properties that hold time_completed property as those are orders that are already finished
                List<Orders> ordersFiltered = response.Orders.Where(s => String.IsNullOrEmpty(s.time_completed)).ToList();
                //removes all orders without any menu items
                ordersFiltered.RemoveAll(s => s.menuItems.Count == 0);

                //filter out all orders which are prepared within ordersFiltered and orders that have been sent to kitchen
                foreach(Orders o in ordersFiltered)
                {
                    ordersFiltered = ordersFiltered.Where(s => s.menuItems.Any(m => !m.prepared ) && s.send_to_kitchen).ToList();
                }

                RealmManager.RemoveAll<Orders>();
                RealmManager.AddOrUpdate<Orders>(ordersFiltered);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
