using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Newtonsoft.Json;

namespace LogicaDeAppsCore
{
    class ControladorBalance: IControladorBalance
    {

        public async Task<Balance> ConsultarBalanceMensual(string mes, int año)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionBalances + "/Balance?mes=" + mes + "&año=" + año);
                Balance balanceARetornar = JsonConvert.DeserializeObject<Balance>(json, settings);
                return balanceARetornar;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el balance.");
            }
        }

        public async Task<List<Balance>> ConsultarBalanceAnual(int año)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionBalances + "año=" + año);
                List<Balance> balancesARetornar = JsonConvert.DeserializeObject<List<Balance>>(json);
                return balancesARetornar;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el balance.");
            }
        }

        public async Task<Balance> ObtenerBalanceAnual(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {

                //string fechaI = fechaInicio.Month + "/" + fechaInicio.Day + "/" + fechaInicio.Year;

                //string fechaF = fechaFinal.Month + "/" + fechaFinal.Day + "/" + fechaFinal.Year;

                //string parametroI = DateTime.ParseExact(fechaInicio.ToString(), "yy/MM/dd HH:mm:ss",CultureInfo.InvariantCulture).ToString();
                //string parametroF = DateTime.ParseExact(fechaFinal.ToString(), "yy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture).ToString();


                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionBalances + 
                    "/ObtenerBalanceAnual?diaI=" + fechaInicio.Day + "&mesI=" + fechaInicio.Month + "&añoI="+ fechaInicio.Year +
                    "&diaF=" + fechaFinal.Day + "&mesF=" + fechaFinal.Month + "&añoF=" + fechaFinal.Year);
                Balance balanceARetornar = JsonConvert.DeserializeObject<Balance>(json);
                return balanceARetornar;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el balance.");
            }
        }

        public async Task<Registro> ConsultarRegistro(DateTime fecha)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionBalances + "/BuscarRegistro?fecha=" + fecha);

                Registro registro = null;

                registro = JsonConvert.DeserializeObject<Registro>(json);

                return registro;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el registro.");
            }
        }

        public async Task<List<Registro>> ConsultarRegistros(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionBalances + "/BuscarRegistros?fechaInicio=" + fechaInicio + "&fechaFinal=" + fechaFinal);

                List<Registro> registros = null;

                registros = JsonConvert.DeserializeObject<List<Registro>>(json);

                return registros;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar los registros.");
            }
        }
    }
}
