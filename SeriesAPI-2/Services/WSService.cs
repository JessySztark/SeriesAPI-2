using Microsoft.AspNetCore.Mvc;
using SeriesAPI.Models.EntityFramework;
using SeriesAPI_2.ViewModels;
using SeriesAPI_2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Web.Http;
using HttpClient = System.Net.Http.HttpClient;

namespace SeriesAPI_2.Services
{
    class WSService : IService {
        HttpClient client = new HttpClient();
        public WSService(String parameter)
        {
            client.BaseAddress = new Uri(parameter);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Serie>> GetSeriesAsync(String nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> PutSerieAsync(String nomControlleur, int id, Serie serie)
        {
            try
            {
                var reponse = await client.PutAsJsonAsync(nomControlleur + "/" + id, serie);
                reponse.EnsureSuccessStatusCode();
                if (reponse.IsSuccessStatusCode)
                    return true;
                return false;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ActionResult<bool>> PostSerieAsync(String nomControlleur, Serie serie)
        {
            try
            {
                var reponse = await client.PostAsJsonAsync(nomControlleur, serie);
                reponse.EnsureSuccessStatusCode();
                if (reponse.IsSuccessStatusCode)
                    return true;
                return false;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSerieAsync(String nomControlleur, int id)
        {
            try
            {
                var reponse = await client.DeleteAsync(nomControlleur + "/" + id);
                reponse.EnsureSuccessStatusCode();
                if (reponse.IsSuccessStatusCode)
                    return true;
                return false;
            }

            catch (Exception)
            {
                return false;
            }
        }
    }
}