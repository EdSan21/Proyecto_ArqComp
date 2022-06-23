using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_ArqComp.Utils
{
   public static class QueryProcessor
    {
        private static string ProcessInsert(object dataModel)
        {
            StringBuilder sb = new StringBuilder();
            var counter = 0;
            foreach (var PropertyInfo in dataModel.GetType().GetProperties())
            {
                counter++;
                if (PropertyInfo.GetValue(dataModel) != null && counter > 1)
                {
                    sb.Append(PropertyInfo.Name + " , ");
                }
            }
            return sb.ToString().Substring(0, sb.ToString().Length - 2);
        }

        private static string ProcessDataModelInsert (object dataModel)
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            foreach (var PropertyInfo in dataModel.GetType().GetProperties())
            {
                counter++;
                if (PropertyInfo.GetValue(dataModel) != null && counter > 1)
                {
                    counter++;
                    if (PropertyInfo.PropertyType.Name == "DateTime")
                    {

                        if (PropertyInfo.GetValue(dataModel).ToString() != "01/01/0001 12:00:00 a. m.")
                        {
                            DateTime date = Convert.ToDateTime(PropertyInfo.GetValue(dataModel).ToString());
                            sb.Append("'" + date.ToString("yyyy-MM-dd HH:mm:ss") + "' , ");
                        }
                        else
                        {
                            sb.Append("null" + " , ");
                        }
                    }
                    else
                    {
                        sb.Append("'" + PropertyInfo.GetValue(dataModel).ToString() + "' , ");
                    }
                }
               
            }
            return sb.ToString().Substring(0, sb.ToString().Length - 2);
        }
        public static string AddRow(string query, string NombreTabla, object DataModel)
        {
            query = query.Replace("TABLA", NombreTabla).Replace("VALORES", ProcessDataModelInsert(DataModel)).Replace("FIELDS", ProcessInsert(DataModel));
            return query;
        }
    }
}
