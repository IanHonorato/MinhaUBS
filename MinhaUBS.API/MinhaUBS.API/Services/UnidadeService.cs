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
    public class UnidadeService : IUnidadeService
    {
        private readonly MinhaUBSContext _context;
        public UnidadeService(MinhaUBSContext context) {
            _context = context;
        }

        public async Task<bool> CreateUnidade(UnidadeDto unidadeDto)
        {
            Unidade unidade = new Unidade(unidadeDto.Nome, unidadeDto.Endereco, unidadeDto.Localizacao, unidadeDto.Ativa);
            _context.Add(unidade);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteUnidade(int idUnidade)
        {
            try
            {
                var obj = await _context.Unidade.FindAsync(idUnidade);
                _context.Unidade.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new Exception("Não é possível deletar");
            }
        }

        public async Task<List<Unidade>> GetUnidades()
        {
            return await _context.Unidade.ToListAsync();
        }

        public async Task<Unidade> GetUnidadesByID(int idUnidade)
        {
            var obj = await _context.Unidade.FindAsync(idUnidade);
            return obj;
        }

        public async Task UpdateUnidade(UnidadeUpdate request)
        {
            bool hasAny = await _context.Unidade.AnyAsync(x => x.ID_Unidade == request.IDUnidade);
            if (!hasAny)
                throw new Exception("ID dessa unidade não existe");
            try
            {
                Unidade unidade = await _context.Unidade.FindAsync(request.IDUnidade);
                unidade.Nome = request.Nome;
                unidade.Endereco = request.Endereco;
                unidade.Localizacao = request.Localizacao;
                unidade.Ativa = request.Ativa;
                
                _context.Update(unidade);
                await _context.SaveChangesAsync();

            } catch(DbUpdateConcurrencyException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
