using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.APIs.DTOs
{
    // KBA Category

    // Add/Edit class for KnowledgeBaseCategory
    public class AddEditKnowledgeBaseCategory
    {
        public Guid? KnowledgeBaseCategoryId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public Guid? ParentId { get; set; }

    }

    // Listing class for KnowledgeBaseCategory (used for filtering and pagination)
    public class KnowledgeBaseCategory_Listing : TableParam
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public int Status { get; set; }
    }

    // View model class for KnowledgeBaseCategory (used for displaying data)
    public class VW_KnowledgeBaseCategory : ListingLogFields
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public Guid? ParentId { get; set; }
    }

    //KBA 
    // Add/Edit class for KnowledgeBaseArticle
    public class AddEditKnowledgeBaseArticle
    {
        public Guid? KnowledgeBaseArticleId { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }

        public string Summary { get; set; }

        public Guid? CategoryId { get; set; }

        // Attachments and Tags lists for the article
        public List<string> Attachments { get; set; }
        public List<string> Tags { get; set; }
    }

    // Listing class for KnowledgeBaseArticle (used for filtering and pagination)
    public class KnowledgeBaseArticle_Listing : TableParam
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? CategoryId { get; set; }
        public int Status { get; set; }
        public string Summary { get; set; }

        // List of tags to filter articles by
        public List<string> Tags { get; set; }
    }

    // View model class for KnowledgeBaseArticle (used for displaying data)
    public class VW_KnowledgeBaseArticle : ListingLogFields
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }


        // List of attachments as strings (file paths, URLs, etc.)
        public string Attachments { get; set; }

        public Guid? CategoryId { get; set; }

        // Virtual list of tags (from related entities)
        public virtual List<string> Tags { get; set; }
    }

}
