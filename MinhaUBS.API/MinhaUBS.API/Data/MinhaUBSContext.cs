using Microsoft.EntityFrameworkCore;
using MinhaUBS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaUBS.API.Data
{
    public class MinhaUBSContext : DbContext
    {
        public MinhaUBSContext(DbContextOptions<MinhaUBSContext> options)
           : base(options)
        {
        }

        public DbSet<Unidade> Unidade { get; set; }
        public DbSet<Vacina> Vacina { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Servico> Servico { get; set; }
    }
}
