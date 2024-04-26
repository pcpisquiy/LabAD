using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicaNegocio.Sesion;
using LogicaNegocio.DTO;
namespace LabAD_Katas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarPacientes()
        {
            GestorClinica gestorClinica = new GestorClinica(FuncionesAuxiliares.Instance.DesEncripta(Properties.Settings.Default.CadenaConexion,"DMP_2024"));
            ViewData["ListaPaciente"] = gestorClinica.ListaPacientes();
            return View();
        }
        public ActionResult InsertarPaciente() {
            return View();
        }
        [HttpPost]
        public ActionResult InsertarPacientes(string Nombre, int Edad, int Telefono)
        {
            GestorClinica gestorClinica = new GestorClinica(FuncionesAuxiliares.Instance.DesEncripta(Properties.Settings.Default.CadenaConexion, "DMP_2024"));
            gestorClinica.InsertarPaciente(new PacienteDTO() { Nombre_Paciente = Nombre, Edad = Edad, Telefono = Telefono });
            return View();
        }

    }
}