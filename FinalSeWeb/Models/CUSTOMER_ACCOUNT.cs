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
    
    public partial class CUSTOMER_ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER_ACCOUNT()
        {
            this.ORDER_LIST = new HashSet<ORDER_LIST>();
        }
    
        public string UserName { get; set; }
        public string Customer_ID { get; set; }
        public string Account_Password { get; set; }
        public Nullable<int> Customer_Level { get; set; }
        public string code_forgot_pass { get; set; }
        public Nullable<System.DateTime> Date_Create_Code_Forgot { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_LIST> ORDER_LIST { get; set; }
    }
}
