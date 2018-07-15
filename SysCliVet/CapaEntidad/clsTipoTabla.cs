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
        public String Nombre { get; set; }
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
                new SqlMetaData("Nombre", SqlDbType.NVarChar, 50),
                new SqlMetaData("Descripcion", SqlDbType.NVarChar, -1),
                new SqlMetaData("Estado", SqlDbType.SmallInt)

                );
            foreach (tVacuna data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetDateTime(1, data.Fecha);
                ret.SetString(2, data.Nombre);
                ret.SetString(3, data.Descripcion);
                ret.SetInt16(4, data.Estado);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tDesparasitacion
    {
        public Int32 Id { get; set; }
        public DateTime Fecha { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public Int16 Estado { get; set; }
    }

    [Serializable]
    public class tListaDesparasitacion : List<tDesparasitacion>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("Id", SqlDbType.Int),
                new SqlMetaData("Fecha", SqlDbType.Date),
                new SqlMetaData("Nombre", SqlDbType.NVarChar, 50),
                new SqlMetaData("Descripcion", SqlDbType.NVarChar, -1),
                new SqlMetaData("Estado", SqlDbType.SmallInt)
                );
            foreach (tDesparasitacion data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetDateTime(1, data.Fecha);
                ret.SetString(2, data.Nombre);
                ret.SetString(3, data.Descripcion);
                ret.SetInt16(4, data.Estado);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tAnalisis
    {
        public Int32 Id { get; set; }
        public Int32 HistoriaClinicaId { get; set; }
        public Int16 TipoAnalisisId { get; set; }
        public Int16 Estado { get; set; }
        public String Descripcion { get; set; }
    }

    [Serializable]
    public class tListaAnalisis : List<tAnalisis>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("Id", SqlDbType.Int),
                new SqlMetaData("HistoriaClinicaID", SqlDbType.Int),
                new SqlMetaData("Descripcion", SqlDbType.NVarChar, 100),
                new SqlMetaData("TipoAnalisisId", SqlDbType.SmallInt),
                new SqlMetaData("Estado", SqlDbType.SmallInt)
                );
            foreach (tAnalisis data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetInt32(1, data.HistoriaClinicaId);
                ret.SetString(2, data.Descripcion);
                ret.SetInt16(3, data.TipoAnalisisId);
                ret.SetInt16(4, data.Estado);
                yield return ret;
            }
        }
    }

    [Serializable]
    public class tTratamiento
    {
        public Int32 Id { get; set; }
        public DateTime FechaTratamiento { get; set; }
        public String Droga { get; set; }
        public String Dosis { get; set; }
        public String Observacion { get; set; }
        public Int16 Estado { get; set; }
    }

    [Serializable]
    public class tListaTratamientos : List<tTratamiento>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("Id", SqlDbType.Int),
                new SqlMetaData("FechaTratamiento", SqlDbType.Date),
                new SqlMetaData("Droga", SqlDbType.NVarChar, 100),
                new SqlMetaData("Dosis", SqlDbType.NVarChar, 100),
                new SqlMetaData("Observacion", SqlDbType.NVarChar, -1),
                new SqlMetaData("Estado", SqlDbType.SmallInt)

                );
            foreach (tTratamiento data in this)
            {
                ret.SetInt32(0, data.Id);
                ret.SetDateTime(1, data.FechaTratamiento);
                ret.SetString(2, data.Droga);
                ret.SetString(3, data.Dosis);
                ret.SetString(4, data.Observacion);
                ret.SetInt16(5, data.Estado);
                yield return ret;
            }
        }
    }

}
