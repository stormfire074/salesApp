using SalesApp.Shared.APIs.DTOs.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.APIs.DTOs
{
    public class SAPDatabasesModel: BaseEntity
    {
        public int Id {  get; set; }
        public string DBKey {  get; set; }  
    }
}
