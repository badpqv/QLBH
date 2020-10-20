using DAL_QLBH;
using DTO_QLBH;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLBH
{
   public class BUS_Hang
    {
        DAL_Hang dalHang = new DAL_Hang();
        public DataTable getHang()
        {
            return dalHang.getHang();
        }
        public bool InsertHang(DTO_Hang hang)
        {
            return dalHang.InsertHang(hang);
        }
        public bool UpdateHang(DTO_Hang hang)
        {
            return dalHang.UpdateHang(hang);
        }
        public bool DeleteHang(int maHang)
        {
            return dalHang.DeleteHang(maHang);
        }
        public DataTable SearchHang(string maHang)
        {
            return dalHang.SearchHang(maHang);
        }
    }
}
