using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiTieuLuan.DAL;
using BaiTieuLuan.ViewModel;

namespace BaiTieuLuan.BLL
{
    internal class PhongBanBLL
    {
        public static List<PhongBan> GetList()
        {
            QLNhanVienModel model = new QLNhanVienModel();
            var ls = model.PhongBans.ToList();//select* from LopHoc
            return ls;

        }

        public static List<PhongBanViewModel> GetListViewModel()
        {
            QLNhanVienModel model = new QLNhanVienModel();
            var ls = model.PhongBans.Select(e => new PhongBanViewModel
            {
                ID = e.ID,
                Name = e.Name,
                TotalNhanVien = e.NhanViens.Count,
            }).ToList();
            return ls;
        }

        public static bool Delete(long idPhongban)
        {
            QLNhanVienModel model = new QLNhanVienModel();
            var lopHoc = model.PhongBans.Where(e => e.ID == idPhongban).FirstOrDefault();
            if (lopHoc.NhanViens.Count == 0)
            {
                model.PhongBans.Remove(lopHoc);
                model.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
