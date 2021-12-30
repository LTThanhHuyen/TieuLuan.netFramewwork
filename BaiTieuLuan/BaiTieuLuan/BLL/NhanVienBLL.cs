using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiTieuLuan.DAL;

namespace BaiTieuLuan.BLL
{
    internal class NhanVienBLL
    {
        public static List<NhanVien> GetList(long maPhong)
        {
            QLNhanVienModel model = new QLNhanVienModel();
            var ls = model.NhanViens.Where(e => e.IDPhongBan == maPhong).ToList();//select* from SinhVien where IDLopHoc=maLop
            return ls;

        }

        public static int Count(long maPhong)
        {
            //dếm trong DB
            QLNhanVienModel model = new QLNhanVienModel();
            var d = model.NhanViens.Where(e => e.IDPhongBan == maPhong).Count();
            return d;
            //return 0; lấy dl ra r đêm
        }

        public static void Delete(string idNhanVien)
        {
            QLNhanVienModel model = new QLNhanVienModel();
            var sinhVien = model.NhanViens.Where(e => e.IDNhanVien == idNhanVien).FirstOrDefault();

            model.NhanViens.Remove(sinhVien);
            model.SaveChanges();
            return;
        }
    }
}
