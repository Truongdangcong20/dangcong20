using BLL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class DonHangBusiness : IDonHangBusiness
    {
        private IDonHangRepository _res;
        public DonHangBusiness(IDonHangRepository res)
        {
            _res = res;
        }
        public List<DonHangModel> GetByIdKh(string idkh)
        {
            return _res.GetByIdKh(idkh);
        }
        public bool Create(DonHangModel model)
        {
            return _res.Create(model);
        }
        public bool Update(DonHangModel model)
        {
            return _res.Update(model);
        }
        public List<DonHangModel> Search(int pageIndex, int pageSize, out long total, string tenkh, string ngaylap)
        {
            return _res.Search(pageIndex,pageSize,out total, tenkh, ngaylap);
        }
    }
}
