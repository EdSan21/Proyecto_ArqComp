using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_ArqComp.DataClass
{
   public static class QueriesRepo
    {
        public const string AddRow = "INSERT INTO TABLA VALUES (VALORES)";
        public enum TipoQuery { AddRow }
    }
}
