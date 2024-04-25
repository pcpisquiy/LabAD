using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabAD_Katas.Controllers
{
    public class FuncionesAuxiliares
    {
        private FuncionesAuxiliares() { }
        private static FuncionesAuxiliares _Instance = null; 
    public static  FuncionesAuxiliares Instance
    {
        get {
                if (_Instance == null) {
                    _Instance = new FuncionesAuxiliares();
                }
                return _Instance;
        }
    }
        public string Encripta(string Pass, string Clave)
        {
            try
            {
                int i;
                string Pass2;
                string CAR, Codigo;
                Pass2 = "";
                for (i = 0; i < Pass.Length; i++)
                {
                    CAR = Pass[i].ToString();
                    Codigo = Clave[(i % Clave.Length)].ToString();
                    Pass2 += (Convert.ToInt32(Codigo[0]) ^ Convert.ToInt32(CAR[0])).ToString("X2");
                }
                return Pass2;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public string DesEncripta(string Pass, string Clave)
        {
            try
            {
                int i;
                string Pass2;
                string CAR, Codigo;
                int j = 0;
                Pass2 = "";
                for (i = 0; i < Pass.Length; i += 2)
                {
                    CAR = Pass.Substring(i, 2);
                    Codigo = Clave[(j % Clave.Length)].ToString();
                    Pass2 += (char)(Convert.ToInt32(Codigo[0]) ^ Convert.ToInt32(CAR, 16));
                    j++;
                }
                return Pass2;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}