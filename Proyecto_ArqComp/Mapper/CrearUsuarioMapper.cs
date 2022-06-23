using Modelos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_ArqComp.Mapper
{
    public class CrearUsuarioMapper : MapperBase<CrearUsuario>
    {
        protected override CrearUsuario Mapp(IDataRecord registro)
        {
            try
            {
                CrearUsuario usuarioModel = new CrearUsuario
                {
                    ID_Usuario = registro["ID_Usuario"] == DBNull.Value ? 0 : (int)registro["ID_Usuario"],
                    Email = registro["Email"] == DBNull.Value ? string.Empty : (string)registro["Email"],
                    Password = registro["Password"] == DBNull.Value ? string.Empty : (string)registro["Password"]
                };
                return usuarioModel;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
