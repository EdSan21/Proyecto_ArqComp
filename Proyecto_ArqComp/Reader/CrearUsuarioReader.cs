using Modelos.Models;
using Proyecto_ArqComp.DataClass;
using Proyecto_ArqComp.Mapper;
using Proyecto_ArqComp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Proyecto_ArqComp.DataClass.QueriesRepo;

namespace Proyecto_ArqComp.Reader
{
    public class CrearUsuarioReader:ObjectReaderWithConnection<CrearUsuario>
    {
        private string DefaultCommand = "SELECT * FROM Registro_Usuario;";
        protected override string CommandText => DefaultCommand;
        public CrearUsuarioReader (TipoQuery Type, CrearUsuario usuarioModel)
        {
            switch (Type)
            {
                case TipoQuery.AddRow:
                    this.DefaultCommand = QueryProcessor.AddRow(QueriesRepo.AddRow, "Registro_Usuario", usuarioModel);
                    break;
                default:
                    break;
            }
        }
        protected override CommandType CommandType => CommandType.Text;
        protected override MapperBase<CrearUsuario> GetMapper()
        {
            MapperBase<CrearUsuario> mapper = new CrearUsuarioMapper();
            return mapper;
        }
        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }
    }
}
