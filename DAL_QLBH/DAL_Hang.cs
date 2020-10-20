using DTO_QLBH;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBH
{
    public class DAL_Hang:DbConnect
    {
        public DataTable getHang()
        {
            DataTable dtHang = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from hang", _con);
            da.Fill(dtHang);
            return dtHang;
        }
        public bool InsertHang(DTO_Hang hang)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_InsertHANG]";
                cmd.Parameters.AddWithValue("TenHang", hang.TenHang);
                cmd.Parameters.AddWithValue("SoLuong", hang.SoLuong);
                cmd.Parameters.AddWithValue("GiaNhap", hang.GiaNhap);
                cmd.Parameters.AddWithValue("GiaBan", hang.GiaBan);
                cmd.Parameters.AddWithValue("HinhAnh", hang.HinhAnh);
                cmd.Parameters.AddWithValue("GhiChu", hang.GhiChu);
                cmd.Parameters.AddWithValue("Email", hang.EmailNv);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _con.Close();
            }
            return false;
        }
        public bool UpdateHang(DTO_Hang hang)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_UpdateHANG]";
                cmd.Parameters.AddWithValue("TenHang", hang.TenHang);
                cmd.Parameters.AddWithValue("SoLuong", hang.SoLuong);
                cmd.Parameters.AddWithValue("GiaNhap", hang.GiaNhap);
                cmd.Parameters.AddWithValue("GiaBan", hang.GiaBan);
                cmd.Parameters.AddWithValue("HinhAnh", hang.HinhAnh);
                cmd.Parameters.AddWithValue("GhiChu", hang.GhiChu);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _con.Close();
            }
            return  false;
        }
        public bool DeleteHang(int maHang)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_DeleteHANG]";
                cmd.Parameters.AddWithValue("MaHang", maHang);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _con.Close();
            }
            return false;
        }
        public DataTable SearchHang(string tenHang)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_SearchHang]";
                cmd.Parameters.AddWithValue("tenHang", tenHang);
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally
            {
                _con.Close();
            }
        }
    }
}
