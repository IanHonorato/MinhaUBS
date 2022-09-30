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

        public async Task<bool> CreateServico(ServicoDto servicoDto)
        {
            Servico servico = new Servico(servicoDto.Nome);
            _context.Add(servico);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteServico(int idServico)
        {
            try
            {
                var obj = await _context.Servico.FindAsync(idServico);
                _context.Servico.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new Exception("Não é possível deletar");
            }
        }

        public async Task<List<Servico>> GetServicos()
        {
            return await _context.Servico.ToListAsync();
        }

        public async Task<Servico> GetServicoByID(int idServico)
        {
            var obj = await _context.Servico.FindAsync(idServico);
            return obj;
        }

        public async Task UpdateServico(ServicoUpdate request)
        {
            bool hasAny = await _context.Servico.AnyAsync(x => x.ID_Servico == request.ID_Servico);
            if (!hasAny)
                throw new Exception("ID dessa unidade não existe");
            try
            {
                Servico servico = await _context.Servico.FindAsync(request.ID_Servico);
                servico.Nome = request.Nome;

                _context.Update(servico);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
