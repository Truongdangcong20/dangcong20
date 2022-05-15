using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    
    public partial interface IDonHangBusiness
    {
        List<DonHangModel> GetByIdKh(string idkh);
        bool Create(DonHangModel model);
        bool Update(DonHangModel model);
        List<DonHangModel> Search(int pageIndex, int pageSize, out long total, string tenkh, string ngaylap);
    }
}
