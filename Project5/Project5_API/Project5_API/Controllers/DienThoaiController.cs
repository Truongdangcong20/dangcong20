using BLL.Interfaces;
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
    [Route("api/[controller]")]
    [ApiController]
    public class DienThoaiController : Controller
    {
        private IDienThoaiBusiness _DienThoaiBusiness;
        private string _path;
        public DienThoaiController(IDienThoaiBusiness DienThoaiBusiness, IConfiguration configuration)
        {
            _DienThoaiBusiness = DienThoaiBusiness;
            _path = configuration["AppSettings:PATH"];
        }

        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }

        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<DienThoaiModel> GetListAll()
        {
            return _DienThoaiBusiness.GetListAll();
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public DienThoaiModel GetById(string id)
        {
            return _DienThoaiBusiness.GetById(id);
        }
        [Route("create")]
        [HttpPost]
        public DienThoaiModel CreateDienThoai([FromBody] DienThoaiModel model)
        {
            if (model.AnhBia != null)
            {
                var arrData = model.AnhBia.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/product/{arrData[0]}";
                    model.AnhBia = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _DienThoaiBusiness.Create(model);
            return model;
        }
        [Route("update")]
        [HttpPut]
        public DienThoaiModel Update([FromBody] DienThoaiModel model)
        {
            if (model.AnhBia != null)
            {
                var arrData = model.AnhBia.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/product/{arrData[0]}";
                    model.AnhBia = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _DienThoaiBusiness.Update(model);
            return model;
        }
        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody] Dictionary<string, object> formData)
        {
            string id = "";
            if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { id = Convert.ToString(formData["id"]); }
            _DienThoaiBusiness.Delete(id);
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
                string idHang = "";
                if (formData.Keys.Contains("idHang") && !string.IsNullOrEmpty(Convert.ToString(formData["idHang"]))) { idHang = Convert.ToString(formData["idHang"]); }
                string tenDT = "";
                if (formData.Keys.Contains("tenDT") && !string.IsNullOrEmpty(Convert.ToString(formData["tenDT"]))) { tenDT = Convert.ToString(formData["tenDT"]); }
                long total = 0;
                var data = _DienThoaiBusiness.Search(page, pageSize, out total, idHang, tenDT);
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
