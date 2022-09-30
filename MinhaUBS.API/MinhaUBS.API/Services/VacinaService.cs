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

        public async Task<bool> CreateVacina(VacinaDto vacinaDto)
        {
            Vacina vacina = new Vacina(vacinaDto.Nome);
            _context.Add(vacina);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteVacina(int idVacina)
        {
            try
            {
                var obj = await _context.Vacina.FindAsync(idVacina);
                _context.Vacina.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new Exception("Não é possível deletar");
            }
        }

        public async Task<List<Vacina>> GetVacinas()
        {
            return await _context.Vacina.ToListAsync();
        }

        public async Task<Vacina> GetVacinasByID(int idVacina)
        {
            var obj = await _context.Vacina.FindAsync(idVacina);
            return obj;
        }

        public async Task UpdateVacina(VacinaUpdate request)
        {
            bool hasAny = await _context.Vacina.AnyAsync(x => x.ID_Vacina == request.ID_Vacina);
            if (!hasAny)
                throw new Exception("ID dessa unidade não existe");
            try
            {
                Vacina vacina = await _context.Vacina.FindAsync(request.ID_Vacina);
                vacina.Nome = request.Nome;
                
                _context.Update(vacina);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
