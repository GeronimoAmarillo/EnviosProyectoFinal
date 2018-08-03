using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Newtonsoft.Json;

namespace LogicaDeAppsCore
{
    class ControladorEmpleado : IControladorEmpleado
    {
        private int ci;
        private Empleado empleado;


        public async Task<bool> ExisteEmpleado(int ci)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Empleados/ExisteEmpleado?" + "ci=" + ci);

                bool existe = false;

                existe = JsonConvert.DeserializeObject<bool>(json);

                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Local con los datos ingresados.");
            }
        }
        public async Task<List<Empleado>> ListarEmpleados()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Empleados/Listar");

                List<Empleado> empleados = null;

                empleados = JsonConvert.DeserializeObject<List<Empleado>>(json);

                return empleados;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los empleados.");
            }
        }

        public Empleado GetEmpleado()
        {
            return new Empleado();
        }

        public void SetEmpleado(Empleado pEmpleado)
        {
            empleado = pEmpleado;
        }

        public Empleado BuscarEmpleado(int ci)
        {
            return new Empleado();
        }

        public bool ModificarEmpleado(Empleado pEmpleado)
        {
            return true;
        }

        public bool EliminarEmpleado(Empleado pEmpleado)
        {
            return true;
        }

        public bool AltaEmpleadoAdministrador(Administrador pEmpleado)
        {
            try
            {

                HttpClient client = new HttpClient();
                Empleado emp = GetEmpleado();

                if (ExisteEmpleado(pEmpleado.Ci).ToString().ToUpper() == "TRUE")
                {
                    throw new Exception("El empleado que desea dar de alta ya existe en el sistema.");
                }

                string url = "http://localhost:8080/api/Empleados/Alta";

                var content = new StringContent(JsonConvert.SerializeObject(pEmpleado), Encoding.UTF8, "application/json");

                var result = client.PostAsync(url, content).Result;

                return result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR!: " + ex.Message);
            }
        }

        public bool AltaEmpleadoCadete(Cadete pEmpleado)
        {
            try
            {

                HttpClient client = new HttpClient();
                Empleado emp = GetEmpleado();

                if (ExisteEmpleado(pEmpleado.Ci).ToString().ToUpper() == "TRUE")
                {
                    throw new Exception("El empleado que desea dar de alta ya existe en el sistema.");
                }

                string url = "http://localhost:8080/api/Empleados/AltaCadete";

                var content = new StringContent(JsonConvert.SerializeObject(pEmpleado), Encoding.UTF8, "application/json");

                var result = client.PostAsync(url, content).Result;

                return result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR!: " + ex.Message);
            }
        }
        public void SetCi(int pCi)
        {
            ci = pCi;
        }

        public Empleado ContemplarTipo()
        {
            return new Empleado();
        }

        public int GetCi()
        {
            return ci;
        }
    }
}
