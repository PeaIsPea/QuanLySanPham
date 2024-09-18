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
    public partial class FrmSanPham : Form
    {
        //tạo List để lưu trữ danh sách danh mục
        public static List<DanhMuc> danhMucs = new List<DanhMuc>();
        List<SanPham> danhsachSP = new List<SanPham>();//lưu trữ dan sách sản phẩm
        public FrmSanPham()
        {
            InitializeComponent();
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frmDM = new FrmDanhMuc();
            FrmDanhMuc.CoThayDoi = false;
            if (frmDM.ShowDialog() == DialogResult.OK)
            {
                HienThiDanhMucLenCB();
            }
        }

        private void HienThiDanhMucLenCB()
        {
            cbDanhMuc.Items.Clear();
            foreach(DanhMuc dm in danhMucs)
            {
                cbDanhMuc.Items.Add(dm);
            }
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(cbDanhMuc.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn danh mục");
                return;
            }
            DanhMuc danhMuc = cbDanhMuc.SelectedItem as DanhMuc;
            SanPham sp =  new SanPham();
            sp.MaSP = txtID.Text;
            sp.TenSP = txtTen.Text;
            sp.DonGia = (double.Parse)(txtDonGia.Text);
            sp.XuatXu = txtXuatXu.Text;
            sp.HSD = dptHSD.Value;

            //đẩy sản phẩm vào danh mục
            danhMuc.ThemSanPham(sp);
            danhsachSP.Add(sp);
            HienThiSanPhamLenListBox();
            XoaTrangChiTietSanPham();
            txtID.Focus();

        }

        void XoaTrangChiTietSanPham()
        {
            txtID.Text = "";
            txtTen.Text = "";
            txtDonGia.Text = "";
            txtXuatXu.Text = "";
        }
        private void HienThiSanPhamLenListBox()
        {
            listBox1.Items.Clear();
            foreach(SanPham sp in danhsachSP)
            {
                listBox1 .Items.Add(sp);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == -1)
            {
                return;
            }
            SanPham sp = listBox1.SelectedItem as SanPham;
            cbDanhMuc.Text = sp.Nhom.TenDM;
            txtID.Text = sp.MaSP;
            txtTen.Text = sp.TenSP;
            txtDonGia.Text = sp.DonGia + "";
            txtXuatXu.Text = sp.XuatXu;
            dptHSD.Value = sp.HSD;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn sản phẩm cần xóa");
            }
            else
            {
                SanPham sp = listBox1 .SelectedItem as SanPham;
                DialogResult ret = MessageBox.Show("Muốn xóa [ " + sp.TenSP + "] hả ný?", "Hỏi xóa", 
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(ret == DialogResult.Yes)
                {
                    danhsachSP.Remove(sp);
                    HienThiSanPhamLenListBox();
                }

            }
        }
    }


}
