using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.DependencyServices
{
    public class DataService<T>
    {
        public List<T> Data { get; set; } = new List<T>();
    }

}
