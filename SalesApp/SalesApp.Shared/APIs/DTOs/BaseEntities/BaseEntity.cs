using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.APIs.DTOs.BaseEntities
{
    public class BaseEntity
    {
        public string Username {  get; set; }
        public string DBName {  get; set; }
        public bool Selected { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
