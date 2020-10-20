using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBH;

namespace DAL_QLBH
{
    public class DAL_NhanVien:DbConnect
    {
        public DataTable getNhanVien()
        {
            DataTable dtNhanvien = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from NhanVien", _con);
            da.Fill(dtNhanvien);
            return dtNhanvien;
        }
        public bool NhanVienDangNhap(DTO_Nhanvien nv)
        {
            try
            {
                _con.Open();
                string sql = "select * from NHANVIEN where email =@email and matkhau = @matkhau";
                SqlCommand cmd = new SqlCommand(sql, _con);
                cmd.Parameters.AddWithValue("@email", nv.EmailNv);
                cmd.Parameters.AddWithValue("@matkhau", nv.MatKhau);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            catch(Exception e)
            {

            }
            finally
            {
                _con.Close();

            }
            return false;
        }
        public bool NhanVienQuenMk(string email)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "QuenMatKhau";
                cmd.Parameters.AddWithValue("@email", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            catch
            {

            }
            finally
            {
                _con.Close();
            }
            return false;
        }
        public bool TaoMatKhau(string email, string matkhaumoi)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TaoMatKhauMoi";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("matkhau", matkhaumoi);
                if(cmd.ExecuteNonQuery()>0)
                    return true;
            }
            catch(Exception e)
            {

            }
            finally
            {
                _con.Close();
            }
            return false;
        }
        public bool UpdateMatKhau(string email,string mkCu, string mkMoi)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ChangePassword";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("opwd", mkCu);
                cmd.Parameters.AddWithValue("npwd", mkMoi);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _con.Close();
            }
            return false;
        }
        public DataTable VaiTroNhanVien(string email)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VaiTroNV";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Connection = _con;
                DataTable dtNhanVien = new DataTable();
                dtNhanVien = new DataTable();
                dtNhanVien.Load(cmd.ExecuteReader());
                return dtNhanVien;
            }
            finally
            {
                _con.Close();
            }
        }
        public bool InsertNhanVien(DTO_Nhanvien nv)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_InsertNHANVIEN]";
                cmd.Connection = _con;
                cmd.Parameters.AddWithValue("Email", nv.EmailNv);
                cmd.Parameters.AddWithValue("HoVaTen", nv.TenNhanVien);
                cmd.Parameters.AddWithValue("DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("VaiTro", nv.VaiTro);
                cmd.Parameters.AddWithValue("TinhTrang", nv.TinhTrang);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _con.Close();
            }
            return false;
        }
        public DataTable SearchNhanVien(string tenNv)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_SearchNhanVien]";
                cmd.Parameters.AddWithValue("tenNV", tenNv);
                DataTable dtNhanVien = new DataTable();
                dtNhanVien.Load(cmd.ExecuteReader());
                return dtNhanVien;
            }
            finally
            {
                _con.Close();
            }
        }
        public bool UpdateNhanVien(DTO_Nhanvien nv)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_UpdateNHANVIEN]";
                cmd.Parameters.AddWithValue("HoVaTen",nv.TenNhanVien);
                cmd.Parameters.AddWithValue("Email", nv.EmailNv);
                cmd.Parameters.AddWithValue("DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("VaiTro", nv.VaiTro);
                cmd.Parameters.AddWithValue("TinhTrang", nv.TinhTrang);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _con.Close();
            }
            return false;
        }
        public bool DeleteNhanVien(string email)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_DeleteNHANVIEN]";
                cmd.Parameters.AddWithValue("email", email);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _con.Close();
            }
            return false;
        }
    }
}
