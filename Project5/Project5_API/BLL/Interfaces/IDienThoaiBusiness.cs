using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface IDienThoaiBusiness
    {
        List<DienThoaiModel> GetListAll();
        DienThoaiModel GetById(string id);
        bool Create(DienThoaiModel model);
        bool Update(DienThoaiModel model);
        bool Delete(string id);
        List<DienThoaiModel> Search(int pageIndex, int pageSize, out long total, string idHang, string tenDT);
    }
}
