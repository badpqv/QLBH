using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBH
{
    public class DbConnect
    {
        protected SqlConnection _con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB;AttachDbFilename = |DataDirectory|\DuAnMau.mdf;Integrated Security =True;");
    }
}
