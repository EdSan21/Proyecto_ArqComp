using Proyecto_ArqComp.Mapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_ArqComp.Reader
{
    public abstract class ObjectReader<T>
    {
        protected abstract IDbConnection GetConnection();
        protected abstract string CommandText { get; }
        protected abstract CommandType CommandType { get;  }
        protected abstract Collection<IDataParameter> GetParameters(IDbCommand command);
        protected abstract MapperBase<T> GetMapper();

        public Collection<T> Execute()
        {
            Collection<T> collection = new Collection<T>();
            using (IDbConnection connection = GetConnection())
            {
                IDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = this.CommandText;
                command.CommandType = this.CommandType;
                foreach (IDataParameter parameter in this.GetParameters(command))
                {
                    command.Parameters.Add(parameter);
                }
                try
                {
                    connection.Open();
                    using (IDataReader lector = command.ExecuteReader())
                    {
                        try
                        {
                            MapperBase<T> mapper = GetMapper();
                            collection = mapper.MapAll(lector);
                            return collection;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        finally
                        {
                            lector.Close();
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
