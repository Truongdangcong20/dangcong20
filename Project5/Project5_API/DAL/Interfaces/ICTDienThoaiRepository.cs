using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface ICTDienThoaiRepository
    {
        List<CTDienThoaiModel> GetListAll();
        List<CTDienThoaiModel> GetByIdDT(string iddt);
        bool Create(CTDienThoaiModel model);
        bool Update(CTDienThoaiModel model);
        bool Delete(string id);
    }
}
