using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LogicaNegocio.DTO;
namespace LogicaNegocio.Entidad
{
    public class Paciente
    {
        private SqlConnection sqlcnn;
        public Paciente(SqlConnection _sqlcnn) { sqlcnn = _sqlcnn; }
        public List<PacienteDTO> ListarPacientes(int? id) {
            string sql = "SP_ListarPaciente";
            SqlCommand cmd = new SqlCommand(sql, sqlcnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", id));
            return CargarReader(cmd.ExecuteReader());
        }

        public void InsertarPaciente(PacienteDTO pacienteDTO)
        {
            string sql = "SP_InsertarPaciente";
            SqlCommand cmd = new SqlCommand(sql, sqlcnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Nombre_Paciente", pacienteDTO.Nombre_Paciente));
            cmd.Parameters.Add(new SqlParameter("@Edad", pacienteDTO.Edad));
            cmd.Parameters.Add(new SqlParameter("@Telefono", pacienteDTO.Telefono));
            cmd.ExecuteScalar();
        }

        protected List<PacienteDTO> CargarReader(SqlDataReader sqlreader)
        {
            List<PacienteDTO> listaPacientes = new List<PacienteDTO>();
            PacienteDTO pacienteDto = null;
            while (sqlreader.Read()) {
                pacienteDto =new  PacienteDTO();
                pacienteDto.IdPaciente = sqlreader.GetInt32(0);
                pacienteDto.Nombre_Paciente = sqlreader.GetString(1);
                pacienteDto.Edad = sqlreader.GetInt32(2);
                pacienteDto.Telefono = sqlreader.GetInt32(3);
                listaPacientes.Add(pacienteDto);
            }
            sqlreader.Close();
            return listaPacientes;
        }
    }
}
