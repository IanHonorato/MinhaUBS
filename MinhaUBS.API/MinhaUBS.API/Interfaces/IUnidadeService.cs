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
        Task AdicionarVacinaNaUnidade(int idUnidade, int idVacina);
        Task AdicionarServicoNaUnidade(int idUnidade, int idServico);
        Task<List<Unidade>> GetUnidadesAtivas();
        Task<List<Vacina>> GetVacinasDaUnidade(int idUnidade);
        Task<List<Servico>> GetServicosDaUnidade(int idUnidade);
        Task<List<Funcionario>> GetFuncionariosNaUnidade(int idUnidade);
    }
}
