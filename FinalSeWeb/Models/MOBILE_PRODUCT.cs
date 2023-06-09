//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalSeWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MOBILE_PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOBILE_PRODUCT()
        {
            this.ORDER_LIST_DETAILS = new HashSet<ORDER_LIST_DETAILS>();
            this.RECEIPT_DETAILS = new HashSet<RECEIPT_DETAILS>();
        }
    
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string TypeProduct_ID { get; set; }
        public string Supplier_ID { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Product_Quantities { get; set; }
        public string Image_Product { get; set; }
    
        public virtual SUPPLIER SUPPLIER { get; set; }
        public virtual TYPE_PRODUCT TYPE_PRODUCT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_LIST_DETAILS> ORDER_LIST_DETAILS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RECEIPT_DETAILS> RECEIPT_DETAILS { get; set; }
    }
}
