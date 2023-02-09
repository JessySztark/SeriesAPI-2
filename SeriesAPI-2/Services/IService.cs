using Microsoft.AspNetCore.Mvc;
using SeriesAPI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAPI_2.Services
{
    interface IService{

        Task<List<Serie>> GetSeriesAsync(String nomController);
        Task<bool> PutSerieAsync(String nomControlleur, int id, Serie serie);
        Task<ActionResult<bool>> PostSerieAsync(String nomController, Serie serie);
        Task<bool> DeleteSerieAsync(String nomController, int id);
    }
}
