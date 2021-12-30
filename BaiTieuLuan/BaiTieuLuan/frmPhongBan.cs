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
using BaiTieuLuan.ViewModel;

namespace BaiTieuLuan
{
    public partial class frmPhongBan : Form
    {
        public frmPhongBan()
        {
            InitializeComponent();
            NapPhongBan();
        }

        void NapPhongBan()
        {
            var ls = PhongBanBLL.GetListViewModel();
            phongBanViewModelBindingSource.DataSource = ls;
            dataGridView1.DataSource = phongBanViewModelBindingSource;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var phongBan = phongBanViewModelBindingSource.Current as PhongBanViewModel;
            if (phongBan != null)
            {
                var rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    if (PhongBanBLL.Delete(phongBan.ID))
                    {
                        phongBanViewModelBindingSource.RemoveCurrent();
                        MessageBox.Show("Đã xóa thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Đã xóa không thành công", "Thông báo");
                    }

                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var f = new frmPhongBanChiTiet();
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                NapPhongBan();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var phongBan = phongBanViewModelBindingSource.Current as PhongBanViewModel;
            if (phongBan != null)
            {
                var f = new frmPhongBanChiTiet(phongBan);
                var rs = f.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    NapPhongBan();
                }

            }
        }
    }
}
