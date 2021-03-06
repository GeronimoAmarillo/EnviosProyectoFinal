﻿using System;
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
    class ControladorTurno:IControladorTurno
    {
        private Turno turno;

        public void IniciarRegistroTurno()
        {
            SetTurno(new Turno());

        }
        public async Task<bool> ExisteTurno(string dia, string hora)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Turnos/ExisteTurno?" + "dia=" + dia + "&hora=" + hora);

                bool existe = false;

                existe = JsonConvert.DeserializeObject<bool>(json);

                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del turno con los datos ingresados.");
            }
        }

        public async Task<Turno> BuscarTurno(string codigo)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionTurnos + "/Turno?codigo=" + codigo);

                Turno turno = null;

                turno = JsonConvert.DeserializeObject<Turno>(json);

                return turno;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el turno.");
            }
        }

        public bool Eliminar(Turno pTurno)
        {
            try
            {

                HttpClient client = new HttpClient();

                //if (ExisteTurno(turno.Dia,turno.Hora.ToString()).ToString().ToUpper() == "FALSE")
                //{
                //    throw new Exception("El turno que desea modificar no existe en el sistema.");
                //}

                string url = ConexionREST.ConexionTurnos + "/Eliminar";

                var content = new StringContent(JsonConvert.SerializeObject(pTurno), Encoding.UTF8, "application/json");

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

        public Turno GetTurno()
        {
            return turno;
        }

        public void SetTurno(Turno pTurno)
        {
            turno = pTurno;
        }

        public bool RegistrarTurno()
        {
            try
            {

                HttpClient client = new HttpClient();
                Turno turno = GetTurno();

                if (ExisteTurno(turno.Dia, turno.Hora.ToString()).ToString().ToUpper() == "FALSE")
                {
                    throw new Exception("El turno que desea dar de alta ya existe en el sistema.");
                }

                string url = "http://localhost:8080/api/Turnos/Alta";

                var content = new StringContent(JsonConvert.SerializeObject(turno), Encoding.UTF8, "application/json");

                var result = client.PostAsync(url, content).Result;

                return result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR!: " + ex.Message);
            }
        }


        public async Task<List<Turno>> ListarTurnos()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionTurnos + "/Turnos");

                List<Turno> turnos = null;

                turnos = JsonConvert.DeserializeObject<List<Turno>>(json);

                return turnos;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los turnos.");
            }
        }
    }
}
