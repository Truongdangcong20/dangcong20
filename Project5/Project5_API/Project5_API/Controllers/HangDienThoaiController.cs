using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project5_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangDienThoaiController : ControllerBase
    {
        private IHangDienThoaiBusiness _HangDienThoaiBusiness;
        public HangDienThoaiController(IHangDienThoaiBusiness HangDienThoaiBusiness)
        {
            _HangDienThoaiBusiness = HangDienThoaiBusiness;
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<HangDienThoaiModel> GetListAll()
        {
            return _HangDienThoaiBusiness.GetListAll();
        }
        [Route("create")]
        [HttpPost]
        public HangDienThoaiModel Create([FromBody] HangDienThoaiModel model)
        {

            _HangDienThoaiBusiness.Create(model);
            return model;
        }
        [Route("update")]
        [HttpPut]
        public HangDienThoaiModel Update([FromBody] HangDienThoaiModel model)
        {
            _HangDienThoaiBusiness.Update(model);
            return model;
        }
        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody] Dictionary<string, object> formData)
        {
            string id = "";
            if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { id = Convert.ToString(formData["id"]); }
            _HangDienThoaiBusiness.Delete(id);
            return Ok();
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
                string tenHang = "";
                if (formData.Keys.Contains("tenHang") && !string.IsNullOrEmpty(Convert.ToString(formData["tenHang"]))) { tenHang = Convert.ToString(formData["tenHang"]); }
                long total = 0;
                var data = _HangDienThoaiBusiness.Search(page, pageSize, out total, tenHang);
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
