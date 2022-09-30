using MinhaUBS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaUBS.API.Interfaces
{
    public interface IVacinaService
    {
        Task<List<Vacina>> GetVacinas();
        Task<Vacina> GetVacinasByID(int idVacina);
        Task<bool> CreateVacina(VacinaDto unidadeDto);
        Task UpdateVacina(VacinaUpdate request);
        Task DeleteVacina(int idVacina);
    }
}
