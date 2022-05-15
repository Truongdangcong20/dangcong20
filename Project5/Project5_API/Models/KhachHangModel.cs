using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class KhachHangModel
    {
        public string Id { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string TenKH { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
    }
}
