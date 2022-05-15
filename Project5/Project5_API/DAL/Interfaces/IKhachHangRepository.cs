using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IKhachHangRepository
    {
        KhachHangModel GetAccount(string taikhoan, string matkhau);
        KhachHangModel GetbyAccountName(string taikhoan);
        bool Create(KhachHangModel model);
        bool Update(KhachHangModel model);
        bool Delete(string id);
        List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string tenkh, string taikhoan);
    }
}
