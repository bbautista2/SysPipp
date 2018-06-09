using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    [Serializable]
    public class tVacuna
    {
        public Int32 Id { get; set; }
        public DateTime Fecha { get; set; }
        public String Descripcion { get; set; }
        public Int16 Estado { get; set; }
    }

    [Serializable]
    public class tListaVacunas : List<tVacuna>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("Id", SqlDbType.Int),
                new SqlMetaData("Fecha", SqlDbType.Date),
                new SqlMetaData("Descripcion", SqlDbType.NVarChar, -1),
                new SqlMetaData("Estado", SqlDbType.SmallInt)

                );
            foreach (tVacuna data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetDateTime(1, data.Fecha);
                ret.SetString(2, data.Descripcion);
                ret.SetInt16(3, data.Estado);
                yield return ret;
            }
        }
    }

}
