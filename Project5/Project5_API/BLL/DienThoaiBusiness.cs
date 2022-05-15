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
    public partial class DienThoaiBusiness: IDienThoaiBusiness
    {
        private IDienThoaiRepository _res;
        public List<DienThoaiModel> GetListAll()
        {
            return _res.GetListAll();
        }
        public DienThoaiModel GetById(string id)
        {
            return _res.GetById(id);
        }
        public DienThoaiBusiness(IDienThoaiRepository ProductRes)
        {
            _res = ProductRes;
        }
        public bool Create(DienThoaiModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            return _res.Create(model);
        }
        public bool Update(DienThoaiModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<DienThoaiModel> Search(int pageIndex, int pageSize, out long total, string idHang, string tenDT)
        {
            return _res.Search(pageIndex, pageSize, out total, idHang, tenDT);
        }
    }
}
