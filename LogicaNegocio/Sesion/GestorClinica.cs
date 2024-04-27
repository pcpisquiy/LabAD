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
        Suceso _Suceso = null;
        public GestorClinica(string _sqlcnn) {
            sqlcnn = new SqlConnection(_sqlcnn);
        }

        public List<PacienteDTO> ListaPacientes(int? id) {
            try
            {
                sqlcnn.Open();
                if (_Paciente == null) { _Paciente = new Paciente(sqlcnn); }
                if (_Suceso == null) { _Suceso = new Suceso(sqlcnn); }
                _Suceso.InsertarSuceso(new SucesoDTO { suceso = "Lista del paciente con el id: " + id.ToString() });
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

                if (_Suceso == null) { _Suceso = new Suceso(sqlcnn); }
                _Suceso.InsertarSuceso(new SucesoDTO { suceso = "Insertar paciente con el nombre: " + pacienteDTO.Nombre_Paciente });
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

        public List<SucesoDTO> ListarSuceso()
        {
            try
            {
                sqlcnn.Open();
                if (_Suceso == null) { _Suceso = new Suceso(sqlcnn); }
                _Suceso.InsertarSuceso(new SucesoDTO { suceso = "Lista de los sucesos"});
                return _Suceso.ListarSuceso();
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
