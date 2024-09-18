using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanPham
{
    public class DanhMuc
    {
        //tạo 1 cái collections để lưu trữ Sản phẩm vào danh mục bằng Dict
        private Dictionary<string, SanPham> dsSP = new Dictionary<string, SanPham>();
        public string MaDM { get; set; }
        public string TenDM { get; set; }

        public void ThemSanPham(SanPham sp)
        {
            if(this.dsSP.ContainsKey(sp.MaSP)== false)
            {
                this.dsSP.Add(sp.MaSP, sp);
                sp.Nhom = this;

            }
            else
            {
                Console.WriteLine("Trùng mã rồi");
            }
            
            

        }


        //trả về danh sách sản phẩm
        public Dictionary<string, SanPham> SanPhams
        {
            get { return SanPhams; }
            set { SanPhams = value; }
        }

        public override string ToString()
        {
            return this.TenDM;
        }

    }
}
