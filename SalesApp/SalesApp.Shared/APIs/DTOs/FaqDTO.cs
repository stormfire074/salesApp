using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.APIs.DTOs
{
    public interface ISelectable
    {
        bool Selected { get; set; }
    }
    public class DataTableColumnDefinition<TItem>
    {
        public string Header { get; set; } = string.Empty;
        public Expression<Func<TItem, object>> Property { get; set; }
        public RenderFragment<TItem>? Template { get; set; }
    }
    //Faq Category
    public class FaqCategory_Listing : TableParam
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public int Status { get; set; }
    }

    public class VW_FaqCategory : ListingLogFields
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
    }

    public class AddEditFaqCategory
    {
        public Guid? FaqCategoryId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public Guid? ParentId { get; set; }
    }

    //Faq 

    // Add/Edit class for Faq
    public class AddEditFaq
    {
        public Guid? FaqId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public Guid? CategoryId { get; set; }
        public int Status { get; set; }
    }

    // Listing class for Faqs (used for filtering and pagination)
    public class Faq_Listing : TableParam
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public Guid? CategoryId { get; set; }
        public int Status { get; set; }
    }

    // View model class for Faq (used for displaying data)
    public class VW_Faq : ListingLogFields
    {
        public Guid Id { get; set; }

        public string Question { get; set; }
        public string Answer { get; set; }

        // Computed property for Switch binding
        public bool IsActive
        {
            get => Status == 1;
            set => Status = value ? 1 : 0;
        }
        public int Status { get; set; }


        public Guid? CategoryId { get; set; }
        public bool Selected { get; set ; }
    }
}
