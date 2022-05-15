using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface INhanVienRepository
    {
        NhanVienModel GetAccount(string taikhoan, string matkhau);
        NhanVienModel GetByID(string id);
        bool Create(NhanVienModel model);
        bool Update(NhanVienModel model);
        bool Delete(string id);
        List<NhanVienModel> Search(int pageIndex, int pageSize, out long total, string tennv, string taikhoan);
    }
}
