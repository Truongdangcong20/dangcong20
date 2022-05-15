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
    public partial class HangDienThoaiBusiness : IHangDienThoaiBusiness
    {
        private IHangDienThoaiRepository _res;
        public HangDienThoaiBusiness(IHangDienThoaiRepository HangDienThoaiRes)
        {
            _res = HangDienThoaiRes;
        }
        public List<HangDienThoaiModel> GetListAll()
        {
            return _res.GetListAll();
        }
        public bool Create(HangDienThoaiModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            return _res.Create(model);
        }
        public bool Update(HangDienThoaiModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<HangDienThoaiModel> Search(int pageIndex, int pageSize, out long total, string tenHang)
        {
            return _res.Search(pageIndex, pageSize, out total, tenHang);
        }
    }
}