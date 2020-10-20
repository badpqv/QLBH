using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBH
{
   public class DTO_Nhanvien
    {
        private string _tenNhanVien;
        private string _diaChi;
        private int _vaiTro;
        private string _emailNv;
        private string _matKhau;
        private int _tinhTrang;

        public string TenNhanVien { get => _tenNhanVien; set => _tenNhanVien = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public int VaiTro { get => _vaiTro; set => _vaiTro = value; }
        public string EmailNv { get => _emailNv; set => _emailNv = value; }
        public string MatKhau { get => _matKhau; set => _matKhau = value; }
        public int TinhTrang { get => _tinhTrang; set => _tinhTrang = value; }
        public DTO_Nhanvien(string emailNv,string tenNv,string diaChi,int vaiTro,int tinhTrang,string matKhau)
        {
            this.EmailNv = emailNv;
            this.TenNhanVien = tenNv;
            this.DiaChi = diaChi;
            this.VaiTro = vaiTro;
            this.TinhTrang = tinhTrang;
            this.MatKhau = matKhau;
        }
        public DTO_Nhanvien(string emailNv,string tenNv,string diaChi,int vaiTro,int tinhTrang)
        {
            this.EmailNv = emailNv;
            this.TenNhanVien = tenNv;
            this.DiaChi = diaChi;
            this.VaiTro = vaiTro;
            this.TinhTrang = tinhTrang;
        }
        public DTO_Nhanvien()
        {

        }
    }
}
