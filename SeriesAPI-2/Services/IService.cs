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
        Task<List<Serie>> PutAsync(String nomController);
        Task<List<Serie>> PostAsync(String nomController);
        Task<List<Serie>> DeleteAsync(String nomController);
    }
}
