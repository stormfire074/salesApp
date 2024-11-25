using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using SalesApp.Shared.APIs.DTOs;

namespace SalesApp.Shared.APIs.Contracts
{
    public interface IRestfulApi
    {

        [Post("/Account/Login")]
        Task<object> Login(object request);
        
        [Get("/Account/SAPCOMPANYLIST")]
        Task<ListResponse<SAPDatabasesModel>> GetAllSapDatabases(ListRequest<SAPDatabasesModel> request);




        [Post("/Services/ItemsController/Api/ItemsList")]
        Task<ListResponse<ItemsModel>> ItemsList(ListRequest<ItemsModel> request);

    }
}   
