using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.Gaming.Input;

namespace KitchenApp.Models.Requests
{
    public class GetIngredientsRequest : ServiceRequest
    {
        public override string Url => "https://dijkstras-steakhouse-restapi.herokuapp.com/ingredients";
        public override HttpMethod Method => HttpMethod.Get;
        public override Dictionary<string, string> Headers => null;
    
        public static async Task<bool> SendGetIngredientsListRequest()
        {
            var sendGetIngredientsListRequest = new GetIngredientsRequest();
            var response = await ServiceRequestHandler.MakeServiceCall<IngredientsList>(sendGetIngredientsListRequest);

            if (response != null)
            {
                RealmManager.RemoveAll<IngredientsList>();
                RealmManager.AddOrUpdate<IngredientsList>(response);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
