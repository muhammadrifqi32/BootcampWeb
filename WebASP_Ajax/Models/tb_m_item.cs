//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebASP_Ajax.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_m_item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public Nullable<int> Supplier_Id { get; set; }
    
        public virtual tb_m_supplier tb_m_supplier { get; set; }
    }
}
