namespace BaiTieuLuan.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        public long ID { get; set; }

        [StringLength(20)]
        public string IDNhanVien { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(200)]
        public string POB { get; set; }

        public long? IDPhongBan { get; set; }

        public virtual PhongBan PhongBan { get; set; }
    }
}
