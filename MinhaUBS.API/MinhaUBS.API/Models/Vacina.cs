using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaUBS.API.Models
{
    public class Vacina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Vacina{ get; set; }
        public string Nome { get; set; }
        public ICollection<Unidade> Unidades { get; set; }
        public Vacina()
        {
        }

        public Vacina(string nome)
        {
            Nome = nome;
        }
    }
}
