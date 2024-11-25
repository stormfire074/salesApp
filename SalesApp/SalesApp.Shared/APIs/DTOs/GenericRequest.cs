namespace SalesApp.Shared.APIs.DTOs
{
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
    public class Response<T>
    {
        public string QueryString { get; set; }
        public T Entity { get; set; }
        public Error Error { get; set; }
    }
    public class ReportResponse<T>
    {
        public string QueryString { get; set; }
        public string Comments { get; set; }
        public string AttachmentEntry { get; set; }
        public T Entity { get; set; }
        public Error Error { get; set; }
    }
    public class ListResponse<T>
    {
        public System.Collections.Generic.List<T> Entity { get; set; }
        public Error Error { get; set; }
    }


    public class Request<TEntity>
    {
        public string DBName { get; set; }
        public string DBKey { get; set; }
        public string UserName { get; set; }
        public string RequestURL { get; set; }
        public string QueryString { get; set; }
        public TEntity Entity { get; set; }

    }
    public class ReportRequest<TEntity>
    {
        public string QueryString { get; set; }
        public string DBName { get; set; }
        public string UserName { get; set; }
        public string RequestURL { get; set; }
        public TEntity Entity { get; set; }

    }
    public class ListRequest<TEntity>
    {
        public string DBName { get; set; }
        public string UserName { get; set; }
        public string RequestURL { get; set; }
        public string TableName { get; set; }
        public TEntity Entity { get; set; }
    }
}
