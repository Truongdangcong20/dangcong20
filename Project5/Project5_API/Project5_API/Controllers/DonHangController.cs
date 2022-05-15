using BLL.Interfaces;
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
    public class DonHangController : Controller
    {
        private IDonHangBusiness _DonHangBusiness;
        public DonHangController(IDonHangBusiness DonHangBusiness)
        {
            _DonHangBusiness = DonHangBusiness;
        }
        [Route("get-by-idkh/{idkh}")]
        [HttpGet]
        public IEnumerable<DonHangModel> GetByIdKh(string idkh)
        {
            return _DonHangBusiness.GetByIdKh(idkh);
        }
        [Route("create")]
        [HttpPost]
        public DonHangModel Create([FromBody] DonHangModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            _DonHangBusiness.Create(model);
            return model;
        }
        [Route("update")]
        [HttpPut]
        public DonHangModel Update([FromBody] DonHangModel model)
        {
            _DonHangBusiness.Update(model);
            return model;
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
                string tenKH = "";
                if (formData.Keys.Contains("tenKH") && !string.IsNullOrEmpty(Convert.ToString(formData["tenKH"]))) { tenKH = Convert.ToString(formData["tenKH"]); }
                string ngayLap = "";
                if (formData.Keys.Contains("ngayLap") && !string.IsNullOrEmpty(Convert.ToString(formData["ngayLap"]))) { ngayLap = Convert.ToString(formData["ngayLap"]); }
                long total = 0;
                var data = _DonHangBusiness.Search(page, pageSize, out total, tenKH, ngayLap);
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
