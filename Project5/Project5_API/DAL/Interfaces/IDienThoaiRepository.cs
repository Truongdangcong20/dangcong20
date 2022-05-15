using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IDienThoaiRepository
    {
        List<DienThoaiModel> GetListAll();
        DienThoaiModel GetById(string id);
        bool Create(DienThoaiModel model);
        bool Update(DienThoaiModel model);
        bool Delete(string id);
        List<DienThoaiModel> Search(int pageIndex, int pageSize, out long total, string idHang, string tenDT);
    }
}
