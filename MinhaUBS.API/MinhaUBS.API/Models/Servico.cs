using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaUBS.API.Models
{
    public class Servico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Servico { get; set; }
        public string Nome { get; set; }
        public Servico()
        {
        }

        public Servico(string nome)
        {
            Nome = nome;
        }
    }
}
