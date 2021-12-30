using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTieuLuan.ViewModel;
using BaiTieuLuan.DAL;

namespace BaiTieuLuan
{
    public partial class frmPhongBanChiTiet : Form
    {
        PhongBanViewModel phongBan;
        public frmPhongBanChiTiet(PhongBanViewModel phongBan=null)
        {
            InitializeComponent();
            this.phongBan = phongBan;
            if (phongBan == null)
            {
                this.Text = "Thêm mới phòng ban";
            }
            else
            {
                this.Text = "Cập nhật dữ liệu cho phòng ban";
                txtTenPhong.Text = phongBan.Name;
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var tenPhong = txtTenPhong.Text;
            if (string.IsNullOrEmpty(tenPhong))
            {
                //MessageBox.Show("Vui long nhạp ten lop")
                errorProvider1.SetError(txtTenPhong, "Vui lòng nhập tên phòng ban");
                return;
            }
            QLNhanVienModel model = new QLNhanVienModel();
            if (phongBan == null)
            {
                //them mới

                var lh = model.PhongBans.Where(t => t.Name == tenPhong).FirstOrDefault();
                if (lh != null)
                {
                    MessageBox.Show("Tên phòng trùng. Vui lòng nhập tên khác", "Chú ý");
                    return;
                }
                else
                {
                    lh = new PhongBan
                    {
                        Name = tenPhong
                    };
                    model.PhongBans.Add(lh);
                    model.SaveChanges();
                    DialogResult = DialogResult.OK;

                }
            }
            else
            {
                // cập nhật

                var lh = model.PhongBans.Where(t => t.ID != phongBan.ID && t.Name == tenPhong).FirstOrDefault();
                if (lh != null)
                {
                    MessageBox.Show("Tên phòng ban trùng. Vui lòng nhập tên khác", "Chú ý");
                    return;
                }
                else
                {
                    lh = model.PhongBans.Where(t => t.ID == phongBan.ID).FirstOrDefault();
                    lh.Name = tenPhong;
                    model.SaveChanges();
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
