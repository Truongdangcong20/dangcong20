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
    public partial class CTDienThoaiBusiness : ICTDienThoaiBusiness
    {
        private ICTDienThoaiRepository _res;
        public List<CTDienThoaiModel> GetListAll()
        {
            return _res.GetListAll();
        }
        public List<CTDienThoaiModel> GetByIdDT(string iddt)
        {
            return _res.GetByIdDT(iddt);
        }
        public CTDienThoaiBusiness(ICTDienThoaiRepository ProductRes)
        {
            _res = ProductRes;
        }
        public bool Create(CTDienThoaiModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            return _res.Create(model);
        }
        public bool Update(CTDienThoaiModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
    }
}
