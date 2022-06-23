using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Clases.Conexion
{
   public class Connection
    {
        public string ConnectionDB()
        {
            SqlConnection conDB = new SqlConnection();
            return conDB.ConnectionString = @"Server=DESKTOP-O7AN31F\SQLEXPRESS;Database=SugoiJapan-DB;Trusted_Connection=true";
        }
    }
}
