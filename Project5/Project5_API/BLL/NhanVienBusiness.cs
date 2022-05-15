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
    public partial class NhanVienBusiness : INhanVienBusiness
    {
        private INhanVienRepository _res;
        private string Secret;
        public NhanVienBusiness(INhanVienRepository res, IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
            _res = res;
        }
        public NhanVienModel Authenticate(string taikhoan, string matkhau)
        {
            var NhanVien = _res.GetAccount(taikhoan, matkhau);
            // return null if NhanVien not found
            if (NhanVien == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, NhanVien.TenNV.ToString()),
                    new Claim(ClaimTypes.Role, NhanVien.Quyen)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            NhanVien.token = tokenHandler.WriteToken(token);

            return NhanVien;

        }
        public NhanVienModel GetByID(string id)
        {
            return _res.GetByID(id);
        }
        public bool Create(NhanVienModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NhanVienModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<NhanVienModel> Search(int pageIndex, int pageSize, out long total, string tennv, string taikhoan)
        {
            return _res.Search(pageIndex, pageSize, out total, tennv, taikhoan);
        }
    }
}
