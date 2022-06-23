using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_ArqComp.Mapper
{
    public abstract class MapperBase <T>
    {
        protected abstract T Mapp(IDataRecord registro);

        public Collection<T> MapAll(IDataReader lector)
        {
            Collection<T> coleccion = new Collection<T>();
            while(lector.Read())
            {
                try
                {
                    coleccion.Add(Mapp(lector));
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return coleccion;
        }
        
    }
}
