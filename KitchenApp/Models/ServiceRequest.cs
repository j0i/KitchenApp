using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace KitchenApp.Models
{
    public abstract class ServiceRequest
    {
        public abstract string Url { get; }
        public abstract HttpMethod Method { get; }
        public abstract Dictionary<string, string> Headers { get; }
    }
}
