//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNT2_2210900089_VuVietAnh.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class THANH_TOAN
    {
        public int MaTT { get; set; }
        public string PhuongThuc { get; set; }
        public Nullable<byte> TrangThai { get; set; }
        public int MaDH { get; set; }
    
        public virtual DON_HANG DON_HANG { get; set; }
    }
}
