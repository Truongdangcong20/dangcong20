using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DonHangModel
    {
        public string Id { get; set; }
        public string IdKhachHang { get; set; }
        public string IdNhanVien { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChiNhan { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public DateTime? NgayLap { get; set; }
        public long ThanhTien { get; set; }
        public string PTThanhToan { get; set; }
        public int TrangThai { get; set; }
        public List<CTDonHangModel> listjson_chitiet { get; set; }

    }
}
