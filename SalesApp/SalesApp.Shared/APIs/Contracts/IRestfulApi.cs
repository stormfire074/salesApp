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
        #region Auth Controller

        [Post("/auth/Login")]
        Task<Response<TokenResponse>> Login([Body] TokenRequest model);

        [Put("/auth/Logout")]
        Task<ResponseWithBool> Logout();


        #endregion Zoho Ticket

        #region

        [Post("/Zoho/CreateTicket")]
        Task<Response<ZohoTicket>> CreateTicket([Body] ZohoTicket ticket);

        #endregion

        #region Zoho Departments

        [Get("/Zoho/GetDepartments")]
        Task<Response<ZohoDepartmentDTO>> GetDepartments();

        #endregion

        #region Zoho Products

        [Get("/Zoho/GetProducts")]
        Task<Response<ZohoProductDTO>> GetProductsByDepartmentId();

        #endregion

        #region Zoho FAQs Category

        [Post("/FaqCategory/GetAll")]
        Task<RootCountResponse<VW_FaqCategory>> GetAllFaqCategory([Body] FaqCategory_Listing model);

        [Get("/FaqCategory/Get/{id}")]
        Task<Response<AddEditFaqCategory>> GetSingleFaqCategory(Guid id);

        [Post("/FaqCategory/Create")]
        Task<Response<AddEditFaqCategory>> CreateFaqCategory([Body] AddEditFaqCategory model);

        [Put("/FaqCategory/Update")]
        Task<Response<AddEditFaqCategory>> UpdateFaqCategory([Body] AddEditFaqCategory model);

        #endregion

        #region Zoho FAQs

        [Post("/Faq/GetAll")]
        Task<RootCountResponse<VW_Faq>> GetAllFaq([Body] Faq_Listing model);

        [Get("/Faq/Get/{id}")]
        Task<Response<AddEditFaq>> GetSingleFaq(Guid id);

        [Post("/Faq/Create")]
        Task<Response<AddEditFaq>> CreateFaq([Body] AddEditFaq model);

        [Put("/Faq/Update")]
        Task<Response<AddEditFaq>> UpdateFaq([Body] AddEditFaq model);

        #endregion

        #region KBA Category

        [Post("/KnowledgeBaseCategory/GetAll")]
        Task<RootCountResponse<VW_KnowledgeBaseCategory>> GetAllKnowledgeBaseCategory([Body] KnowledgeBaseCategory_Listing model);

        [Get("/KnowledgeBaseCategory/Get/{id}")]
        Task<Response<AddEditKnowledgeBaseCategory>> GetSingleKnowledgeBaseCategory(Guid id);

        [Post("/KnowledgeBaseCategory/Create")]
        Task<Response<AddEditKnowledgeBaseCategory>> CreateKnowledgeBaseCategory([Body] AddEditKnowledgeBaseCategory model);

        [Put("/KnowledgeBaseCategory/Update")]
        Task<Response<AddEditKnowledgeBaseCategory>> UpdateKnowledgeBaseCategory([Body] AddEditKnowledgeBaseCategory model);

        #endregion

        #region KBA

        [Post("/KnowledgeBaseArticle/GetAll")]
        Task<RootCountResponse<VW_KnowledgeBaseArticle>> GetAllKnowledgeBaseArticle([Body] KnowledgeBaseArticle_Listing model);

        [Get("/KnowledgeBaseArticle/Get/{id}")]
        Task<Response<AddEditKnowledgeBaseArticle>> GetSingleKnowledgeBaseArticle(Guid id);

        [Post("/KnowledgeBaseArticle/Create")]
        Task<Response<AddEditKnowledgeBaseArticle>> CreateKnowledgeBaseArticle([Body] AddEditKnowledgeBaseArticle model);

        [Put("/KnowledgeBaseArticle/Update")]
        Task<Response<AddEditKnowledgeBaseArticle>> UpdateKnowledgeBaseArticle([Body] AddEditKnowledgeBaseArticle model);

        #endregion
    }
}   
