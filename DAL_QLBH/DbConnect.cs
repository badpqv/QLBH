using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBH
{
    public class DbConnect
    {
        static string conStr = ConfigurationManager.ConnectionStrings["QLBH"].ToString();
        protected static SqlConnection _con = new SqlConnection(conStr);
    }
}
