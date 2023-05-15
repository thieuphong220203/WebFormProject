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
    
    public partial class ACCOUNTANT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACCOUNTANT()
        {
            this.GOOD_DELIVERY = new HashSet<GOOD_DELIVERY>();
            this.WAREHOUSE_RECEIPT = new HashSet<WAREHOUSE_RECEIPT>();
        }
    
        public string Accountant_ID { get; set; }
        public string Accountant_Name { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> Accountant_Birth { get; set; }
        public string Accountant_Address { get; set; }
        public string Accountant_Email { get; set; }
        public string Accountant_Phone { get; set; }
        public string Accountant_UserName { get; set; }
        public string Accountant_Password { get; set; }
        public byte[] Accountant_Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOOD_DELIVERY> GOOD_DELIVERY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WAREHOUSE_RECEIPT> WAREHOUSE_RECEIPT { get; set; }
    }
}
