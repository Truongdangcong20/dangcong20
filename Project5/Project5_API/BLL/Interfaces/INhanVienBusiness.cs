using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface INhanVienBusiness
    {
        NhanVienModel GetByID(string id);
        NhanVienModel Authenticate(string taikhoan, string matkhau);
        bool Create(NhanVienModel model);
        bool Update(NhanVienModel model);
        bool Delete(string id);
        List<NhanVienModel> Search(int pageIndex, int pageSize, out long total, string tennv, string taikhoan);
    }
}
