using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.APIs.DTOs
{
    public class ZohoTicket
    { 
        public string id { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string departmentId { get; set; }
        public string contactId { get; set; }
        [Required]
        public string productId { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
        public string channel { get; set; }
        [Required]
        public string priority { get; set; }
    }

}
