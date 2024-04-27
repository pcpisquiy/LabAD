using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LogicaNegocio.Entidad;
using LogicaNegocio.DTO;

namespace LogicaNegocio.Sesion
{
    public class GestorClinica
    {
        SqlConnection sqlcnn = null;
        Paciente _Paciente = null;
        public GestorClinica(string _sqlcnn) {
            sqlcnn = new SqlConnection(_sqlcnn);
        }

        public List<PacienteDTO> ListaPacientes(int? id) {
            try
            {
                sqlcnn.Open();
                if (_Paciente == null) { _Paciente = new Paciente(sqlcnn); }
                return _Paciente.ListarPacientes(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally {
                if (sqlcnn.State != ConnectionState.Closed) {
                    sqlcnn.Close();
                }
            }
        }
        public void InsertarPaciente(PacienteDTO pacienteDTO)
        {
            try
            {
                sqlcnn.Open();
                if (_Paciente == null) { _Paciente = new Paciente(sqlcnn); }
                _Paciente.InsertarPaciente(pacienteDTO);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (sqlcnn.State != ConnectionState.Closed)
                {
                    sqlcnn.Close();
                }
            }
        }
    }
}
