using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project5_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhachHangController : Controller
    {
        private IKhachHangBusiness _KhachHangBusiness;
        public KhachHangController(IKhachHangBusiness KhachHangBusiness)
        {
            _KhachHangBusiness = KhachHangBusiness;
        }

        [Route("login")]
        [HttpPost]
        public KhachHangModel GetAccount([FromBody] KhachHangModel model)
        {
            return _KhachHangBusiness.GetAccount(model.TaiKhoan, model.MatKhau);
        }
        [Route("delete")]
        [HttpPost]
        public IActionResult Delete([FromBody] Dictionary<string, object> formData)
        {
            string id = "";
            if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) {id = Convert.ToString(formData["id"]); }
            _KhachHangBusiness.Delete(id);
            return Ok();
        }

        [Route("register")]
        [HttpPost]
        public KhachHangModel Create([FromBody] KhachHangModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            _KhachHangBusiness.Create(model);
            return model;
        }

        [Route("update")]
        [HttpPost]
        public KhachHangModel Update([FromBody] KhachHangModel model)
        {
            _KhachHangBusiness.Update(model);
            return model;
        }

        [Route("get-by-accountname/{taikhoan}")]
        [HttpGet]
        public KhachHangModel GetbyAccountName(string taikhoan)
        {
            return _KhachHangBusiness.GetbyAccountName(taikhoan);
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string taikhoan = "";
                if (formData.Keys.Contains("taiKhoan") && !string.IsNullOrEmpty(Convert.ToString(formData["taiKhoan"]))) { taikhoan = Convert.ToString(formData["taiKhoan"]); }
                string tenkh = "";
                if (formData.Keys.Contains("tenKH") && !string.IsNullOrEmpty(Convert.ToString(formData["tenKH"]))) { tenkh = Convert.ToString(formData["tenKH"]); }
                long total = 0;
                var data = _KhachHangBusiness.Search(page, pageSize, out total, tenkh, taikhoan);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
