using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface IHangDienThoaiBusiness
    {
        List<HangDienThoaiModel> GetListAll();
        bool Create(HangDienThoaiModel model);
        bool Update(HangDienThoaiModel model);
        bool Delete(string id);
        List<HangDienThoaiModel> Search(int pageIndex, int pageSize, out long total, string TenHang);
    }
}
