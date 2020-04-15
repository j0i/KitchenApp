using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

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
                RealmManager.AddOrUpdate<OrdersList>(response);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
