using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenApp.Models
{
    public class EmployeeList : RealmObject
    {
        public IList<Employee> employees { get; }
    }
}