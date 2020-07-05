using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.data
{
    class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            // neu dung window authencation
            conStr = ConfigurationManager.ConnectionStrings["QLySVien"].ConnectionString.ToString();
            
        
        }

        public SqlConnection getConnection()
        {
            return new SqlConnection(conStr);
        }
    }
}
