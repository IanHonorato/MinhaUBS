using MinhaUBS.API.DTO;
using MinhaUBS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaUBS.API.Interfaces
{
    public interface IServicoService
    {
        Task<List<Servico>> GetServicos();
        Task<Servico> GetServicoByID(int idServico);
        Task<bool> CreateServico(ServicoDto servicoDto);
        Task UpdateServico(ServicoUpdate request);
        Task DeleteServico(int idServico);
        Task<List<Unidade>> GetUnidadesComServico(int idServico);
    }
}
