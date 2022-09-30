using MinhaUBS.API.DTO;
using MinhaUBS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaUBS.API.Interfaces
{
    public interface IFuncionarioService
    {
        Task<List<Funcionario>> GetFuncionarios();
        Task<Funcionario> GetFuncionarioByID(int idFuncionario);
        Task<bool> CreateFuncionario(FuncionarioDto funcionarioDto);
        Task UpdateFuncionario(FuncionarioUpdate request);
        Task DeleteFuncionario(int idFuncionario);
    }
}
