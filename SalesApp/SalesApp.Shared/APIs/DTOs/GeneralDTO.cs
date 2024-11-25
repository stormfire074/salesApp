using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.APIs.DTOs
{
    public class GeneralDTO
    {
    }

    public class TableParam
    {
        public int Start { get; set; }
        public int Limit { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }
    }

    public class ListingLogFields
    {
        public int TotalCount { get; set; }
        public long SerialNo { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; }
        public int? CreatedOn { get; set; }
        public string CreatedDate { get; set; }
    }
}
