using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class KhachHangBusiness : IKhachHangBusiness
    {
        private IKhachHangRepository _res;
        private string Secret;
        public KhachHangBusiness(IKhachHangRepository res)
        {
            _res = res;
        }
        public KhachHangModel GetAccount(string taikhoan, string matkhau)
        {
            return _res.GetAccount(taikhoan, matkhau);
        }
        public KhachHangModel GetbyAccountName(string taikhoan)
        {
            return _res.GetbyAccountName(taikhoan);
        }
        public bool Create(KhachHangModel model)
        {
            return _res.Create(model);
        }
        public bool Update(KhachHangModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string tennv, string taikhoan)
        {
            return _res.Search(pageIndex, pageSize, out total, tennv, taikhoan);
        }
    }
}
