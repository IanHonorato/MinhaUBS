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
    public class FuncionarioService : IFuncionarioService
    {
        private readonly MinhaUBSContext _context;
        public FuncionarioService(MinhaUBSContext context) {
            _context = context;
        }

        public async Task<bool> CreateFuncionario(FuncionarioDto funcionarioDto)
        {
            bool hasAny = await _context.Unidade.AnyAsync(x => x.ID_Unidade == funcionarioDto.ID_Unidade);
            if (!hasAny)
                throw new Exception("ID dessa unidade não existe");
            
            Unidade unidade = await _context.Unidade.FindAsync(funcionarioDto.ID_Unidade);

            Funcionario funcionario = new Funcionario(unidade, funcionarioDto.Nome, funcionarioDto.Login, funcionarioDto.Senha, funcionarioDto.Especialidade);
            _context.Add(funcionario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteFuncionario(int idFuncionario)
        {
            try
            {
                var obj = await _context.Funcionario.FindAsync(idFuncionario);
                _context.Funcionario.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new Exception("Não é possível deletar");
            }
        }

        public async Task<List<Funcionario>> GetFuncionarios()
        {
            return await _context.Funcionario.ToListAsync();
        }

        public async Task<Funcionario> GetFuncionarioByID(int idFuncionario)
        {
            var obj = await _context.Funcionario.FindAsync(idFuncionario);
            return obj;
        }

        public async Task UpdateFuncionario(FuncionarioUpdate request)
        {
            bool hasFuncionario = await _context.Funcionario.AnyAsync(x => x.ID_Funcionario == request.ID_Funcionario);
            if (!hasFuncionario)
                throw new Exception("ID desse funcionário não existe");

            bool hasUnidade = await _context.Unidade.AnyAsync(x => x.ID_Unidade == request.ID_Unidade);
            if (!hasUnidade)
                throw new Exception("ID dessa unidade não existe");
            try
            {
                Funcionario funcionario = await _context.Funcionario.FindAsync(request.ID_Funcionario);
                Unidade unidade = await _context.Unidade.FindAsync(request.ID_Unidade);
                
                funcionario.Nome = request.Nome;
                funcionario.Unidade = unidade;
                funcionario.Login = request.Login;
                funcionario.Senha = request.Senha;
                funcionario.Especialidade = request.Especialidade;

                _context.Update(funcionario);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
