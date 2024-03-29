﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL_QLBH;
using DTO_QLBH;

namespace BUS_QLBH
{
   public class BUS_NhanVien
    {
        DAL_NhanVien dalNhanVien = new DAL_NhanVien();
        public bool NhanVienDangNhap(DTO_Nhanvien nv)
        {
            return dalNhanVien.NhanVienDangNhap(nv);
        }
        
        public string encryption(string pwd)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(pwd));
            StringBuilder encryptdata = new StringBuilder();
            for(int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
         }
        public bool NhanVienQuenMk(string email)
        {
           return dalNhanVien.NhanVienQuenMk(email);
        }
        public bool TaoMatKhau(string email, string mkMoi)
        {
            return dalNhanVien.TaoMatKhau(email, encryption(mkMoi));
        }
        public bool UpdateMatKhau(string email,string mkCu, string mkMoi)
        {
            return dalNhanVien.UpdateMatKhau(email, mkCu, mkMoi);
        }
        public bool InsertNhanVien(DTO_Nhanvien nv)
        {
            return dalNhanVien.InsertNhanVien(nv);
        }
        public bool UpdateNhanVien(DTO_Nhanvien nv)
        {
            return dalNhanVien.UpdateNhanVien(nv);
        }
        public bool DeleteNhanVien(string email)
        {
            return dalNhanVien.DeleteNhanVien(email);
        }
        public DataTable VaiTroNhanVien(string email)
        {
            return dalNhanVien.VaiTroNhanVien(email);
        }
        public DataTable getNhanVien()
        {
            return dalNhanVien.getNhanVien();
        }
        public DataTable SearchNhanVien(string tenNv)
        {
            return dalNhanVien.SearchNhanVien(tenNv);
        }
    }
}
