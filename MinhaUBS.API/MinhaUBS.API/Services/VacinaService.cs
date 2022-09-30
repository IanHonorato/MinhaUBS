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
    public class VacinaService : IVacinaService
    {
        private readonly MinhaUBSContext _context;
        public VacinaService(MinhaUBSContext context) {
            _context = context;
        }

        public Task<bool> CreateVacina(VacinaDto unidadeDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteVacina(int idVacina)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vacina>> GetVacinas()
        {
            throw new NotImplementedException();
        }

        public Task<Vacina> GetVacinasByID(int idVacina)
        {
            throw new NotImplementedException();
        }

        public Task UpdateVacina(VacinaUpdate request)
        {
            throw new NotImplementedException();
        }
    }
}
