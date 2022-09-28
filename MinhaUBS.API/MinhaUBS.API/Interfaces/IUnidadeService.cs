using MinhaUBS.API.DTO;
using MinhaUBS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaUBS.API.Interfaces
{
    public interface IUnidadeService
    {
        Task<List<Unidade>> GetUnidades();
        Task<Unidade> GetUnidadesByID(int idUnidade);
        Task<bool> CreateUnidade(UnidadeDto unidadeDto);
        Task UpdateUnidade(UnidadeUpdate request);
        Task DeleteUnidade(int idUnidade);
    }
}
