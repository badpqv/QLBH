using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBH
{
    public class DTO_Khachhang
    {
        private string _soDienthoai,_tenKhach,_diaChi,_gioiTinh,_emailKhach,_maNv;

        public string SoDienthoai { get => _soDienthoai; set => _soDienthoai = value; }
        public string TenKhach { get => _tenKhach; set => _tenKhach = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public string EmailKhach { get => _emailKhach; set => _emailKhach = value; }
        public string MaNv { get => _maNv; set => _maNv = value; }

        public DTO_Khachhang(string soDienthoai, string tenKhach, string diaChi, string gioiTinh, string emailKhach)
        {
            SoDienthoai = soDienthoai;
            TenKhach = tenKhach;
            DiaChi = diaChi;
            GioiTinh = gioiTinh;
            EmailKhach = emailKhach;
        }
    }
}
