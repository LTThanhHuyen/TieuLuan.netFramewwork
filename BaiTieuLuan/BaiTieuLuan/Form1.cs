using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTieuLuan.BLL;
using BaiTieuLuan.DAL;

namespace BaiTieuLuan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var ls = PhongBanBLL.GetList();
            comboBox1.DataSource = ls;
            comboBox1.DisplayMember = "Name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var phongBan = comboBox1.SelectedItem as PhongBan;
            if (phongBan != null)
            {
                var maPhong = phongBan.ID;
                var ls = NhanVienBLL.GetList(maPhong);

                nhanVienBindingSource.DataSource = ls;
                dataGridView1.DataSource = nhanVienBindingSource;
                //đếm trong DB
                var total = NhanVienBLL.Count(maPhong);
                lblTongSoNV.Text = $"{total} nhân viên";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var nhanVien = nhanVienBindingSource.Current as NhanVien;
            if (nhanVien != null)
            {
                var phongBan = comboBox1.SelectedItem as PhongBan;
                var rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    NhanVienBLL.Delete(nhanVien.IDNhanVien);
                    nhanVienBindingSource.RemoveCurrent();
                    MessageBox.Show("Đã xóa thành công", "Thông báo");
                    var maPhong = phongBan.ID;
                    var total = NhanVienBLL.Count(maPhong);
                    lblTongSoNV.Text = $"{total} nhân viên";
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var f = new frmNhanVienChiTiet();
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                var phongBan = comboBox1.SelectedItem as PhongBan;
                if (phongBan != null)
                {
                    var maPhong = phongBan.ID;
                    var ls = NhanVienBLL.GetList(maPhong);

                    nhanVienBindingSource.DataSource = ls;
                    dataGridView1.DataSource = nhanVienBindingSource;

                    var total = NhanVienBLL.Count(maPhong);
                    lblTongSoNV.Text = $"{total} nhân viên";
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var nhanVien = nhanVienBindingSource.Current as NhanVien;
            if (nhanVien != null)
            {
                var f = new frmNhanVienChiTiet(nhanVien);
                var rs = f.ShowDialog();
                var phongBan = comboBox1.SelectedItem as PhongBan;
                if (rs == DialogResult.OK)
                {
                    var maPhong = phongBan.ID;
                    var ls = NhanVienBLL.GetList(maPhong);

                    nhanVienBindingSource.DataSource = ls;
                    dataGridView1.DataSource = nhanVienBindingSource;

                    var total = NhanVienBLL.Count(maPhong);
                    lblTongSoNV.Text = $"{total} nhân viên";
                }

            }
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
           
            frmPhongBan f = new frmPhongBan();
            f.Show();
        }
    }
}
