using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySanPham
{
    public partial class FrmDanhMuc : Form
    {

        public static bool CoThayDoi = false;
        public FrmDanhMuc()
        {
            InitializeComponent();
        }

        private void btnLuuDanhMuc_Click(object sender, EventArgs e)
        {
            //đưa danh mục vào để hiển thị bên form sản phẩm
            DanhMuc danhMuc = new DanhMuc();
            
            danhMuc.MaDM = txtMaDanhMuc.Text;
            danhMuc.TenDM = txtTenDanhMuc.Text;
            FrmSanPham.danhMucs.Add(danhMuc);
            HienThiDanhMucLenListBox();


            //Clear đi
            txtMaDanhMuc.Text = "";
            txtTenDanhMuc.Text = "";
            txtMaDanhMuc.Focus(); //di chuyển con trỏ tới ô nhập mã
            CoThayDoi = true;
        }

        void HienThiDanhMucLenListBox()
        {
            lstDanhMuc.Items.Clear();
            foreach(DanhMuc dm in FrmSanPham.danhMucs)
            {
                lstDanhMuc.Items.Add(dm);
            }
        }

        private void lstDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstDanhMuc.SelectedIndex != -1)
            {
                DanhMuc dm = lstDanhMuc.SelectedItem as DanhMuc;
                txtMaDanhMuc.Text = dm.MaDM;
                txtTenDanhMuc.Text = dm.TenDM;
            }
        }

        private void btnXoaDanhMuc_Click(object sender, EventArgs e)
        {
            
            if (lstDanhMuc.SelectedIndex!= -1)
            {
                DanhMuc dm = lstDanhMuc.SelectedItem as DanhMuc;
                lstDanhMuc.Items.Remove(dm);
                CoThayDoi = true;
            }
        }

        private void btnThoatDanhMuc_Click(object sender, EventArgs e)
        {
            if(CoThayDoi == true)
            {
                DialogResult= DialogResult.OK;
            }
            else
            {
                DialogResult= DialogResult.Cancel;
            }
        }

        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            HienThiDanhMucLenListBox();
        }
    }
}
