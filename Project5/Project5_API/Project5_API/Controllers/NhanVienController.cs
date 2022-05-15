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
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NhanVienController : Controller
    {
        private INhanVienBusiness _NhanVienBusiness;
        private string _path;
        public NhanVienController(INhanVienBusiness NhanVienBusiness, IConfiguration configuration)
        {
            _NhanVienBusiness = NhanVienBusiness;
            _path = configuration["AppSettings:PATH"];
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var NhanVien = _NhanVienBusiness.Authenticate(model.TaiKhoan, model.MatKhau);

            if (NhanVien == null)
                return BadRequest(new { message = "NhanVienname or password is incorrect" });

            return Ok(NhanVien);
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

        [Route("delete")]
        [HttpPost]
        public IActionResult DeleteNhanVien([FromBody] Dictionary<string, object> formData)
        {
            string NhanVien_id = "";
            if (formData.Keys.Contains("NhanVien_id") && !string.IsNullOrEmpty(Convert.ToString(formData["NhanVien_id"]))) { NhanVien_id = Convert.ToString(formData["NhanVien_id"]); }
            _NhanVienBusiness.Delete(NhanVien_id);
            return Ok();
        }

        [Route("create")]
        [HttpPost]
        public NhanVienModel CreateNhanVien([FromBody] NhanVienModel model)
        {
            if (model.HinhAnh != null)
            {
                var arrData = model.HinhAnh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.HinhAnh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            model.Id = Guid.NewGuid().ToString();
            _NhanVienBusiness.Create(model);
            return model;
        }

        [Route("update")]
        [HttpPost]
        public NhanVienModel UpdateNhanVien([FromBody] NhanVienModel model)
        {
            if (model.HinhAnh != null)
            {
                var arrData = model.HinhAnh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.HinhAnh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _NhanVienBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public NhanVienModel GetDatabyID(string id)
        {
            return _NhanVienBusiness.GetByID(id);
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
                string taiKhoan = "";
                if (formData.Keys.Contains("taiKhoan") && !string.IsNullOrEmpty(Convert.ToString(formData["taiKhoan"]))) { taiKhoan = Convert.ToString(formData["taiKhoan"]); }
                string tenNV = "";
                if (formData.Keys.Contains("tenNVtenNV") && !string.IsNullOrEmpty(Convert.ToString(formData["tenNV"]))) { tenNV = Convert.ToString(formData["tenNV"]); }
                long total = 0;
                var data = _NhanVienBusiness.Search(page, pageSize, out total, tenNV, taiKhoan);
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
