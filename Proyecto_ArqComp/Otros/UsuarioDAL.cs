using BL.Clases.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_ArqComp.Otros
{
    public class UsuarioDAL
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public DataSet Log(string email, string password)
        {
            Connection Conexion = new Connection();
            using (SqlConnection SqlCon = new SqlConnection())
            {
                SqlCon.ConnectionString = Conexion.ConnectionDB();
                SqlCon.Open();
                var Select = "SELECT Email, Password FROM [SugoiJapan-DB].[dbo].[Registro_Usuario] WHERE Email ='" + email + "' AND Password ='" + password + "'";

                var DataAdapter = new SqlDataAdapter(Select, SqlCon);
                var CommandBuilder = new SqlCommandBuilder(DataAdapter);
                var DS = new DataSet();
                DataAdapter.Fill(DS);
                return DS;
            }
        }
        
    }
}
