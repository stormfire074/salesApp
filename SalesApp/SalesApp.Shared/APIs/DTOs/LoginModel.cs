using SalesApp.Shared.APIs.DTOs.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.APIs.DTOs
{
    public class LoginModel:BaseEntity
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string DBKey { get; set; }
        public string CompanyDatabase { get; set; }

        public int IsLoggedIn { get;set; }
    }
}
