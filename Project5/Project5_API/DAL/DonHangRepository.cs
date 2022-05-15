using DAL.Helper;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial  class DonHangRepository: IDonHangRepository
    {
        private IDatabaseHelper _dbHelper;
        public DonHangRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<DonHangModel> GetByIdKh(string idkh)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_dh_get_by_idkh",
                    "@idkh", idkh);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(DonHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_dh_create",
                "@id", model.Id,
                "@idnv", model.IdNhanVien,
                "@idkh", model.IdKhachHang,
                "@tenkh", model.TenKhachHang,
                "@diachi", model.DiaChiNhan,
                "@sdt", model.Sdt,
                "@email", model.Email,
                "@thanhtien", model.ThanhTien,
                "@pttt", model.PTThanhToan,
                "@trangthai", model.TrangThai,
                "@listjson_chitiet", model.listjson_chitiet != null ? MessageConvert.SerializeObject(model.listjson_chitiet) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(DonHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_dh_update",
                "@id", model.Id,
                "@idnv", model.IdNhanVien,
                "@tendt", model.TrangThai
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DonHangModel> Search(int pageIndex, int pageSize, out long total, string tenkh, string ngaylap)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_dh_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@tenkh", tenkh,
                    "@ngaylap", ngaylap
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];

                return dt.ConvertTo<DonHangModel>().ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
