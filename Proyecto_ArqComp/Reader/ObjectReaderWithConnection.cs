using BL.Clases.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_ArqComp.Reader
{
    public abstract class ObjectReaderWithConnection<T> : ObjectReader <T>
    {
        private static  Connection Conexion = new Connection();
        protected override IDbConnection GetConnection()
        {
            IDbConnection connection = new SqlConnection(Conexion.ConnectionDB());
            return connection;
        }
    }
}
