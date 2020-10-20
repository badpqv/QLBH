using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace DTO_QLBH
{
    public class DTO_Hang
    {
        private int _maHang,_soLuong,_giaNhap,_giaBan;
        private string _tenHang;
        private string _hinhAnh;
        private string _ghiChu;
        private string _emailNv;

        public int MaHang { get => _maHang; set => _maHang = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public int GiaNhap { get => _giaNhap; set => _giaNhap = value; }
        public int GiaBan { get => _giaBan; set => _giaBan = value; }
        public string TenHang { get => _tenHang; set => _tenHang = value; }
        public string HinhAnh { get => _hinhAnh; set => _hinhAnh = value; }
        public string GhiChu { get => _ghiChu; set => _ghiChu = value; }
        public string EmailNv { get => _emailNv; set => _emailNv = value; }

        public DTO_Hang(string tenHang,int soLuong, float giaNhap, float giaBan,  string hinhAnh, string ghiChu,string emailNv)
        {
            SoLuong = soLuong;
            GiaNhap = giaNhap;
            GiaBan = giaBan;
            TenHang = tenHang;
            HinhAnh = hinhAnh;
            GhiChu = ghiChu;
            EmailNv = emailNv;
        }
    }
}
