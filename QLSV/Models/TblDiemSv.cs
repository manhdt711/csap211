using System;
using System.Collections.Generic;

#nullable disable

namespace QLSV.Models
{
    public partial class TblDiemSv
    {
        public int Id { get; set; }
        public string MaSv { get; set; }
        public string TenSv { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public decimal? DiemGiuaKy { get; set; }
        public decimal? DiemChuyenCan { get; set; }
        public decimal? DiemCuoiKy { get; set; }
    }
}
