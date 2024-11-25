using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.APIs.DTOs
{
    public class Response<T>
    {
        public NestedResponse<T> Data { get; set; }
        public PayloadMessage Message { get; set; }
    }
    public class NestedResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }

    public class PayloadMessage
    {
        public string Text { get; set; }
        public string Title { get; set; }
        public string MessageTypeId { get; set; }
    }

    public class ResponseWithBool
    {
        public bool Data { get; set; }
        public PayloadMessage Message { get; set; }
    }

    public class RootCountResponse<T>
    {
        public CountResponse<T> Data { get; set; }
        public PayloadMessage Message { get; set; }
    }

    public class CountResponse<T>
    {
        public bool Success { get; set; }
        public InnerCountResponse<T> Data { get; set; }
    }

    public class InnerCountResponse<T>
    {
        public int TotalCount { get; set; }
        public List<T> DataList { get; set; }
    }


}
