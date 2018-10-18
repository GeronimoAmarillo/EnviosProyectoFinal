﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Newtonsoft.Json;

namespace LogicaDeAppsCore
{
    class ControladorCalificacion:IControladorCalificacion
    {
        public bool Calificar(int puntaje, string comentario, long rutCliente)
        {
            try
            {
                Calificacion cal = new Calificacion()
                {
                    Puntaje = puntaje,
                    Comentario = comentario,
                    RutCliente = rutCliente
                };

                HttpClient client = new HttpClient();

                string url = ConexionREST.ConexionAdelantos + "/Adelanto";

                var content = new StringContent(JsonConvert.SerializeObject(cal), Encoding.UTF8, "application/json");

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
    }
}
