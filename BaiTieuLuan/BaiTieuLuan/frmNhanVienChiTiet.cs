using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTieuLuan.DAL;
using BaiTieuLuan.BLL;

namespace BaiTieuLuan
{
    public partial class frmNhanVienChiTiet : Form
    {
        NhanVien nhanVien;
        public frmNhanVienChiTiet(NhanVien nhanVien=null)
        {
            InitializeComponent();
            var ls = PhongBanBLL.GetList();
            comboBox1.DataSource = ls;
            comboBox1.DisplayMember = "Name";

            this.nhanVien = nhanVien;
            if (nhanVien == null)
            {
                this.Text = "Thêm mới nhân viên";

            }
            else
            {
                this.Text = "Cập nhật dữ liệu cho nhân viên";
                txtMaNV.Text = nhanVien.IDNhanVien;
                txtHo.Text = nhanVien.LastName;
                txtTen.Text = nhanVien .FirstName;
                dtpNgaySinh.Value = (DateTime)nhanVien.DOB;
                txtNoiSinh.Text = nhanVien.POB;
               

            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var maNV = txtMaNV.Text;
            if (string.IsNullOrEmpty(maNV))
            {
                errorProvider1.SetError(txtMaNV, "Vui lòng nhập mã nhân viên");
                return;
            }
            var ho = txtHo.Text;
            if (string.IsNullOrEmpty(ho))
            {
                errorProvider1.SetError(txtHo, "Vui lòng nhập họ nhân viên");
                return;
            }
            var ten = txtTen.Text;
            if (string.IsNullOrEmpty(ten))
            {
                errorProvider1.SetError(txtTen, "Vui lòng nhập tên nhân viên");
                return;
            }
            var ngaySinh = dtpNgaySinh.Value;
            var noiSinh = txtNoiSinh.Text;
            if (string.IsNullOrEmpty(noiSinh))
            {
                errorProvider1.SetError(txtNoiSinh, "Vui lòng nhập nơi sinh");
                return;
            }


            var phongBan = comboBox1.SelectedItem as PhongBan;

            QLNhanVienModel model = new QLNhanVienModel();
            if (nhanVien == null)
            {
                //thêm mới
                var nv = model.NhanViens.Where(s => s.IDNhanVien == maNV).FirstOrDefault();
                if (nv != null)
                {
                    MessageBox.Show("Mã nhân viên trùng. Vui lòng nhập mã khác", "Chú ý");
                    return;
                }
                else
                {
                    nv = new NhanVien
                    {
                        IDNhanVien = maNV,
                        FirstName = ten,
                        LastName = ho,
                        DOB = ngaySinh,
                        POB = noiSinh,
                        IDPhongBan = phongBan.ID,

                    };
                    model.NhanViens.Add(nv);
                    model.SaveChanges();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                // cập nhật
                var lh = model.NhanViens.Where(s => s.ID != nhanVien.ID && s.IDNhanVien == maNV).FirstOrDefault();
                if (lh != null)
                {
                    MessageBox.Show("Mã nhân viên trùng. Vui lòng nhập mã nhân viên khác", "Chú ý");
                    return;
                }
                else
                {
                    lh = model.NhanViens.Where(s => s.ID == nhanVien.ID).FirstOrDefault();
                    lh.IDNhanVien = maNV;
                    lh.FirstName = ten;
                    lh.LastName = ho;
                    lh.DOB = ngaySinh;
                    lh.POB = noiSinh;
                    lh.IDPhongBan = phongBan.ID;
                    model.SaveChanges();
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
