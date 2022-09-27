using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaUBS.API.Models
{
    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Funcionario { get; set; }
        public Unidade ID_Unidade { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Especialidade { get; set; }
        public Funcionario()
        {
        }

        public Funcionario(Unidade id_unidade, string nome, string login, string senha, string especialidade)
        {
            ID_Unidade = id_unidade;
            Nome = nome;
            Login = login;
            Senha = senha;
            Especialidade = especialidade;
        }
    }
}
