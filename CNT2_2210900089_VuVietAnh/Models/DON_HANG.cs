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
    
    public partial class DON_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DON_HANG()
        {
            this.CHI_TIET_DON_HANG = new HashSet<CHI_TIET_DON_HANG>();
            this.THANH_TOAN = new HashSet<THANH_TOAN>();
        }
    
        public int MaDH { get; set; }
        public int MaKH { get; set; }
        public System.DateTime NgayDat { get; set; }
        public Nullable<byte> TrangThai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_DON_HANG> CHI_TIET_DON_HANG { get; set; }
        public virtual KHACH_HANG KHACH_HANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANH_TOAN> THANH_TOAN { get; set; }
    }
}
