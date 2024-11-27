using SalesApp.Shared.APIs.DTOs.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.APIs.DTOs
{
    public class ItemsModel:BaseEntity
    {
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? CodeBars { get; set; } = string.Empty;
        public string? BcdCode { get; set; }
        public string? BcdCode2 { get; set; }
        public string? Grp { get; set; }
        public string? Status { get; set; }
        public string? InStock_Badian { get; set; }
        public string? InStock_Lakhoki { get; set; }
        public string? InStock_Khi { get; set; }
        public string? InStock_BOND_LHR { get; set; }
        public string? TRNS_KHI { get; set; }
        public string? TRNS_LHR { get; set; }
        public string? InStock_Total { get; set; }
        public string? Commited { get; set; }
        public string? Availible_InStock_Commited { get; set; }
        public string? Up_Coming { get; set; }
        public string? Tag_Price { get; set; }
        public string? SalePrice { get; set; } = string.Empty;
        public string? DIS_LFT { get; set; }
        public string? DIS_LHR_291_MB { get; set; }
        public string? DIS_CLGR { get; set; }
        public string? DIS_GUJ { get; set; }
        public string? DIS_ISB { get; set; }
        public string? DIS_KHI { get; set; }
        public string? DIS_LHR { get; set; }
        public string? DIS_MON_58MB { get; set; }
        public string? DIS_MUL { get; set; }
        public string? DIS_HNGR { get; set; }
        public string? BRK_Badian { get; set; }
        public string? BRk_ISB { get; set; }
        public string? BRK_KHI { get; set; }
        public string? BRK_LHK { get; set; }
        public string? Chipped { get; set; }
        public string? AIVE_SH { get; set; }
        public string? AIVE_SKT_CONS { get; set; }
        public string? KALE_MUL_CONS { get; set; }
        public string? S_PARTS { get; set; }
        public string? AUDIT_WH { get; set; }
        public string? Size { get; set; }
        public string? Packaging { get; set; }
        public string? NoofTilesBox { get; set; }
        public string? DISP_Stock_Total { get; set; }
        public string? BRK_Stock_Total { get; set; }
        public string? OTHERS_Stock_Total { get; set; }
        public string? NA { get; set; }
        public string? OnHand { get; set; }
        public string? UOM { get; set; }
    }

    
    public class WarehouseWiseStock : BaseWHEntity
    {
        public string ItemCode { get; set; }

        public string BreakageType {  get; set; }
    }
    public class ItemBooking : BaseEntity
    {
        public string ItemCode { get; set; }
        public string SONo { get; set; }
        public string CardName { get; set; }
        public string CardCode { get; set; }
        public string SODate { get; set; }
        public string Qty { get; set; }
        public string Balance { get; set; }
        public string Location { get; set; }
    }
    public class BatchWiseItem : BaseEntity
    {
        public string ItemCode { get; set; }
        public string BatchShade { get; set; }
        public string Qty { get; set; }
        public string WH { get; set; }
    }


    
}
