using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidad.TipoTabla
{
    [Serializable]
    public class TPermisoNavegacion
    {
        public Int32 NavegacionId { get; set; }
    }

    [Serializable]
    public class TListaPermisoNavegacion : List<TPermisoNavegacion>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("NavegacionId", SqlDbType.Int)
                );
            foreach (TPermisoNavegacion data in this)
            {
                ret.SetInt32(0, data.NavegacionId);
                yield return ret;
            }
        }
    }
}
