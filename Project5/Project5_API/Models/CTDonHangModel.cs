using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CTDonHangModel
    {
        public string IdDonHang { get; set; }
        public string IdCTDienThoai { get; set; }
        public string TenDT { get; set; }
        public int Ram { get; set; }
        public int BoNho { get; set; }
        public int DonGia { get; set; }
        public string HinhAnh { get; set; }
        public string MauSac { get; set; }
        public int SoLuongMua { get; set; }

    }
}
