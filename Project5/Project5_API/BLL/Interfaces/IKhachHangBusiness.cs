using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface IKhachHangBusiness
    {
        KhachHangModel GetbyAccountName(string taikhoan);
        KhachHangModel GetAccount(string taikhoan, string matkhau);
        bool Create(KhachHangModel model);
        bool Update(KhachHangModel model);
        bool Delete(string id);
        List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string tennv, string taikhoan);
    }
}
