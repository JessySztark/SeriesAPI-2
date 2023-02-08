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

        public Task<List<Serie>> DeleteAsync(string nomController)
        {
            throw new NotImplementedException();
        }
        
        public Task<List<Serie>> PostAsync(string nomController)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Serie>> PutAsync(string nomController)
        {
            var json = JsonSerializer.Serialize();
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            using var res = await client.PutAsync("api/users/profiles", stringContent);
            res.EnsureSuccessStatusCode();
            return res;
        }
    }
}
