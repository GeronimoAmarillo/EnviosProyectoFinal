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
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionEmpleados+"/Listar");

                List<Empleado> empleados = null;

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };

                empleados = JsonConvert.DeserializeObject<List<Empleado>>(json,settings);

                return empleados;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los empleados.");
            }
        }
        public Cadete GetEmpleadoCad()
        {
            return new Cadete();
        }
        public Administrador GetEmpleadoAdm()
        {
            return new Administrador();
        }
        public Empleado GetEmpleado()
        {
            return new Empleado();
        }

        public void SetEmpleado(Empleado pEmpleado)
        {
            empleado = pEmpleado;
        }

        public async Task<Empleado> BuscarEmpleado(int Id)
        {
            HttpClient client = new HttpClient();
            Empleado emp = GetEmpleado();


            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://localhost:8080/api/Empleados/Empleado?" + "Id=" + Id);

            emp = JsonConvert.DeserializeObject<Empleado>(json);

            return emp;
        }

        public bool ModificarAdmnistrador(Administrador pEmpleado)
        {
            try
            {

                HttpClient client = new HttpClient();

                if (ExisteEmpleado(pEmpleado.Ci).ToString().ToUpper() == "TRUE")
                {
                    throw new Exception("El empleado que desea modificar no existe en el sistema.");
                }

                string url = ConexionREST.ConexionEmpleados + "/Modificar";

                var content = new StringContent(JsonConvert.SerializeObject(pEmpleado), Encoding.UTF8, "application/json");

                var result = client.PostAsync(url, content).Result;

                var contentResult = result.Content.ReadAsStringAsync();

                if (contentResult.Result.ToUpper() == "TRUE")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ERROR!: " + ex.Message);
            }
        }
        public bool ModificarCadete(Cadete pEmpleado)
        {
            try
            {

                HttpClient client = new HttpClient();

                if (ExisteEmpleado(pEmpleado.Ci).ToString().ToUpper() == "FALSE")
                {
                    throw new Exception("El empleado que desea modificar no existe en el sistema.");
                }

                string url = ConexionREST.ConexionEmpleados + "/ModificarCadete";

                var content = new StringContent(JsonConvert.SerializeObject(pEmpleado), Encoding.UTF8, "application/json");

                var result = client.PutAsync(url, content).Result;

                var contentResult = result.Content.ReadAsStringAsync();

                if (contentResult.Result.ToUpper() == "TRUE")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ERROR!: " + ex.Message);
            }
        }
        public bool EliminarEmpleado(Empleado emp)
        {
            try
            {
                HttpClient client = new HttpClient();

              

                string url = ConexionREST.ConexionEmpleados + "/EliminarEmpleado";

                var content = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");

                var result = client.PostAsync(url, content).Result;

                var contentResult = result.Content.ReadAsStringAsync();

                if (contentResult.Result.ToUpper() == "TRUE")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ERROR!: " + ex.Message);
            }
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
