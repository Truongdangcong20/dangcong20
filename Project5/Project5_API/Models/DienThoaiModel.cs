using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DienThoaiModel
    {
        public string Id { get; set; }
        public string TenDT { get; set; }
        public string ManHinh { get; set; }
        public string HeDieuHanh { get; set; }
        public string CameraSau { get; set; }
        public string CameraTruoc { get; set; }
        public string Chip { get; set; }
        public string PinSac { get; set; }
        public string TheSim { get; set; }
        public string MoTa { get; set; }
        public string AnhBia { get; set; }
        public int TrangThai { get; set; }
        public string IdHang { get; set; }
        public List<CTDienThoaiModel>? listjson_ctdt { get; set; }
        public List<BoNhoModel>? listjson_bonho { get; set; }
    }
    public class BoNhoModel
    {
       public int BoNho { get; set; }
    }

}