using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LogicaNegocio.DTO;
namespace LogicaNegocio.Entidad
{
   public class Suceso
    {
        private SqlConnection _sqlcnn = null;
        public Suceso(SqlConnection sqlcnn) {
            _sqlcnn = sqlcnn;
        }
        public void InsertarSuceso(SucesoDTO SucesoDTO) {
                string sql = "SP_InsertarSuceso";
                SqlCommand cmd = new SqlCommand(sql, _sqlcnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Suceso", SucesoDTO.suceso));
                cmd.ExecuteScalar();
        }

        public List<SucesoDTO> ListarSuceso()
        {
            string sql = "SP_ListarSuceso";
            SqlCommand cmd = new SqlCommand(sql, _sqlcnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return CargarReader(cmd.ExecuteReader());
        }
        protected List<SucesoDTO> CargarReader(SqlDataReader sqlreader) {
            List<SucesoDTO> ListaSuceso = new List<SucesoDTO>();
            SucesoDTO _sucesoDTO = null;
            while (sqlreader.Read()) {
                _sucesoDTO = new SucesoDTO();
                _sucesoDTO.idSuceso = sqlreader.GetInt32(0);
                _sucesoDTO.suceso = sqlreader.GetString(1);
                _sucesoDTO.Fecha_Suceso = sqlreader.GetDateTime(2);
                ListaSuceso.Add(_sucesoDTO);             
            }
            return ListaSuceso;
        }
    }
}
