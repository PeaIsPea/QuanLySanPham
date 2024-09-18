using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanPham
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public double DonGia { get; set; }
        public string XuatXu { get; set; }
        public DateTime HSD { get; set; }
        public DanhMuc Nhom { get; set; }// tạo ra để biết một sp thuộc "Nhóm" Danh mục nào
        public override string ToString()
        {
            return this.TenSP;
        }
    }
}
