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
    public class DAL_Khach:DbConnect
     {
        public DataTable getKhach()
        {
            DataTable dtKhach = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from KhachHang",_con);
            da.Fill(dtKhach);
            return dtKhach;
        }
        public bool InsertKhach(DTO_Khachhang khach)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_InsertKHACH]";
                cmd.Parameters.AddWithValue("DienThoai", khach.SoDienthoai);
                cmd.Parameters.AddWithValue("TenKhach", khach.TenKhach);
                cmd.Parameters.AddWithValue("DiaChi", khach.DiaChi);
                cmd.Parameters.AddWithValue("GioiTinh", khach.GioiTinh);
                cmd.Parameters.AddWithValue("email", khach.EmailKhach);
                if (cmd.ExecuteNonQuery() > 0)
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
        public bool UpdateKhach(DTO_Khachhang khach)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_UpdateKHACH]";
                cmd.Parameters.AddWithValue("DienThoai", khach.SoDienthoai);
                cmd.Parameters.AddWithValue("TenKhach", khach.TenKhach);
                cmd.Parameters.AddWithValue("DiaChi", khach.DiaChi);
                cmd.Parameters.AddWithValue("GioiTinh", khach.GioiTinh);
                cmd.Parameters.AddWithValue("email", khach.EmailKhach);
                if (cmd.ExecuteNonQuery() > 0)
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
        public bool DeleteKhach(string soDT)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_DeleteKHACH]";
                cmd.Parameters.AddWithValue("DienThoai", soDT);
                if (cmd.ExecuteNonQuery() > 0)
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
        public DataTable SearchKhach(string tenKhach)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_SearchKhachHang]";
                cmd.Parameters.AddWithValue("tenKhach", tenKhach);
                DataTable dtKhach = new DataTable();
                dtKhach.Load(cmd.ExecuteReader());
                return dtKhach;
            }
            finally
            {
                _con.Close();
            }
        }
     }
}
