using MinhaUBS.API.Data;
using MinhaUBS.API.Interfaces;
using MinhaUBS.API.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MinhaUBS.API.DTO;

namespace MinhaUBS.API.Services
{
    public class ServicoService : IServicoService
    {
        private readonly MinhaUBSContext _context;
        public ServicoService(MinhaUBSContext context) {
            _context = context;
        }

        public Task<bool> CreateServico(ServicoDto servicoDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteServico(int idServico)
        {
            throw new NotImplementedException();
        }

        public Task<List<Servico>> GetServicos()
        {
            throw new NotImplementedException();
        }

        public Task<Servico> GetServicoByID(int idServico)
        {
            throw new NotImplementedException();
        }

        public Task UpdateServico(ServicoUpdate request)
        {
            throw new NotImplementedException();
        }
    }
}
