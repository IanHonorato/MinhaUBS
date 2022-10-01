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

        public async Task AdicionarServicoNaUnidade(int idUnidade, int idServico)
        {
            bool hasServico = await _context.Servico.AnyAsync(x => x.ID_Servico == idServico);
            if (!hasServico)
                throw new Exception("ID desse servico não existe");

            bool hasUnidade = await _context.Unidade.AnyAsync(x => x.ID_Unidade == idUnidade);
            if (!hasUnidade)
                throw new Exception("ID dessa unidade não existe");

            Servico servico = await _context.Servico.FindAsync(idServico);
            Unidade unidade = await _context.Unidade.FindAsync(idUnidade);

            unidade.AddServico(servico);
            _context.Update(unidade);
            await _context.SaveChangesAsync();
        }

        public async Task AdicionarVacinaNaUnidade(int idUnidade, int idVacina)
        {
            bool hasVacina = await _context.Vacina.AnyAsync(x => x.ID_Vacina == idVacina);
            if (!hasVacina)
                throw new Exception("ID dessa vacina não existe");

            bool hasUnidade = await _context.Unidade.AnyAsync(x => x.ID_Unidade == idUnidade);
            if (!hasUnidade)
                throw new Exception("ID dessa unidade não existe");

            Vacina vacina = await _context.Vacina.FindAsync(idVacina);
            Unidade unidade = await _context.Unidade.FindAsync(idUnidade);

            unidade.AddVacina(vacina);
            _context.Update(unidade);
            await _context.SaveChangesAsync();
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

        public async Task<List<Funcionario>> GetFuncionariosNaUnidade(int idUnidade)
        {
            var obj = _context.Funcionario.Where(v => v.Unidade.ID_Unidade == idUnidade));
            return await obj.ToListAsync();
        }

        public async Task<List<Servico>> GetServicosDaUnidade(int idUnidade)
        {
            var obj = _context.Servico.Where(x => x.Unidades.Any(v => v.ID_Unidade == idUnidade));
            return await obj.ToListAsync();
        }

        public async Task<List<Unidade>> GetUnidades()
        {
            return await _context.Unidade.ToListAsync();
        }

        public async Task<List<Unidade>> GetUnidadesAtivas()
        {
            var obj =  _context.Unidade.Where(x => x.Ativa == true);
            return await obj.ToListAsync();
        }

        public async Task<Unidade> GetUnidadesByID(int idUnidade)
        {
            var obj = await _context.Unidade.FindAsync(idUnidade);
            return obj;
        }

        public async Task<List<Vacina>> GetVacinasDaUnidade(int idUnidade)
        {
            var obj = _context.Vacina.Where(x => x.Unidades.Any(v => v.ID_Unidade == idUnidade));
            return await obj.ToListAsync();
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
