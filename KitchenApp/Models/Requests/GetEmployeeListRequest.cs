using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KitchenApp.Models.Requests
{
    public class GetEmployeeListRequest : ServiceRequest
    {
        public override string Url => "https://dijkstras-steakhouse-restapi.herokuapp.com/employees";
        public override HttpMethod Method => HttpMethod.Get;
        public override Dictionary<string, string> Headers => null;

        public static async Task<bool> SendGetEmployeeListRequest()
        {
            var sendGetEmployeeListRequest = new GetEmployeeListRequest();
            var response = await ServiceRequestHandler.MakeServiceCall<EmployeeList>(sendGetEmployeeListRequest);

            if (response != null)
            {
                RealmManager.AddOrUpdate<EmployeeList>(response);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}