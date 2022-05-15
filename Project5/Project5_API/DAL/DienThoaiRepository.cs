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
    public partial class DienThoaiRepository : IDienThoaiRepository
    {
        private IDatabaseHelper _dbHelper;
        public DienThoaiRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<DienThoaiModel> GetListAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_dt_get_list");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DienThoaiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DienThoaiModel GetById(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_dt_get_by_id",
                    "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DienThoaiModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(DienThoaiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_dt_create",
                "@id", model.Id,
                "@tendt", model.TenDT,
                "@manhinh", model.ManHinh,
                "@hedieuhanh", model.HeDieuHanh,
                "@camerasau", model.CameraSau,
                "@cameratruoc", model.CameraTruoc,
                "@chip", model.Chip,
                "@pinsac", model.PinSac,
                "@thesim", model.TheSim,
                "@mota", model.MoTa,
                "@anhbia", model.AnhBia,
                "@trangthai", model.TrangThai,
                "@idhang", model.IdHang
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
        public bool Update(DienThoaiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_dt_update",
                "@id", model.Id,
                "@tendt", model.TenDT,
                "@manhinh", model.ManHinh,
                "@hedieuhanh", model.HeDieuHanh,
                "@camerasau", model.CameraSau,
                "@cameratruoc", model.CameraTruoc,
                "@chip", model.Chip,
                "@pinsac", model.PinSac,
                "@thesim", model.TheSim,
                "@mota", model.MoTa,
                "@anhbia", model.AnhBia,
                "@trangthai", model.TrangThai,
                "@idhang", model.IdHang
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
        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_dt_delete",
                "@id", id);
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
        public List<DienThoaiModel> Search(int pageIndex, int pageSize, out long total, string idHang, string tenDT)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_dt_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@idhang", idHang,
                    "@tendt", tenDT
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                
                return dt.ConvertTo<DienThoaiModel>().ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
