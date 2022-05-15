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
    public class CTDienThoaiController : Controller
    {
        private ICTDienThoaiBusiness _CTDienThoaiBusiness;
        private string _path;
        public CTDienThoaiController(ICTDienThoaiBusiness CTDienThoaiBusiness, IConfiguration configuration)
        {
            _CTDienThoaiBusiness = CTDienThoaiBusiness;
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
        public IEnumerable<CTDienThoaiModel> GetListAll()
        {
            return _CTDienThoaiBusiness.GetListAll();
        }
        [Route("get-by-iddt")]
        [HttpGet]
        public IEnumerable<CTDienThoaiModel> GetByIdDT([FromBody] Dictionary<string, object> formData)
        {
            string iddt = "";
            if (formData.Keys.Contains("idDienThoai") && !string.IsNullOrEmpty(Convert.ToString(formData["idDienThoai"]))) { iddt = Convert.ToString(formData["idDienThoai"]); }
            return _CTDienThoaiBusiness.GetByIdDT(iddt);
        }
        [Route("create")]
        [HttpPost]
        public CTDienThoaiModel CreateCTDienThoai([FromBody] CTDienThoaiModel model)
        {
            if (model.HinhAnh != null)
            {
                var arrData = model.HinhAnh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/product/{arrData[0]}";
                    model.HinhAnh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _CTDienThoaiBusiness.Create(model);
            return model;
        }
        [Route("update")]
        [HttpPut]
        public CTDienThoaiModel Update([FromBody] CTDienThoaiModel model)
        {
            if (model.HinhAnh != null)
            {
                var arrData = model.HinhAnh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/product/{arrData[0]}";
                    model.HinhAnh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _CTDienThoaiBusiness.Update(model);
            return model;
        }
        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody] Dictionary<string, object> formData)
        {
            string id = "";
            if (formData.Keys.Contains("Id") && !string.IsNullOrEmpty(Convert.ToString(formData["Id"]))) { id = Convert.ToString(formData["Id"]); }
            _CTDienThoaiBusiness.Delete(id);
            return Ok();
        }
    }
}
