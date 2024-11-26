using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.APIs.DTOs.BaseEntities
{
    public class BaseWHEntity : BaseEntity
    {
        public string OnHand { get; set; }
        public string WhsCode { get; set; }
        public string WHName { get; set; }
    }
}
