using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTO
{
    public class PacienteDTO
    {
        public int IdPaciente { get; set; }
        public string Nombre_Paciente { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
    }
}
