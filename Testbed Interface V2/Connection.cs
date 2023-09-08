using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testbed_Interface_V2
{
    class Connection
    {
        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-9IGBSEP\\MSSQLSERVER_2022;Initial Catalog=CANS_DT;Persist Security Info=True;User ID=sa;Password=***********";
            return con;
        }
    }


}
