using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IDonHangRepository
    {
        List<DonHangModel> GetByIdKh(string idkh);
        bool Create(DonHangModel model);
        bool Update(DonHangModel model);
        List<DonHangModel> Search(int pageIndex, int pageSize, out long total, string tenkh, string ngaylap);
    }
}
