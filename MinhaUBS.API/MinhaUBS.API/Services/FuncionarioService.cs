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

        public Task<bool> CreateFuncionario(FuncionarioDto funcionarioDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFuncionario(int idFuncionario)
        {
            throw new NotImplementedException();
        }

        public Task<List<Funcionario>> GetFuncionarios()
        {
            throw new NotImplementedException();
        }

        public Task<Funcionario> GetFuncionarioByID(int idFuncionario)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFuncionario(FuncionarioUpdate request)
        {
            throw new NotImplementedException();
        }
    }
}
