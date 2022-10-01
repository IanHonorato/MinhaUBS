using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaUBS.API.Models
{
    public class Unidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Unidade { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Localizacao { get; set; }
        public bool Ativa { get; set; }
        public ICollection<Vacina> Vacinas { get; set; } = new List<Vacina>();
        public ICollection<Servico> Servicos { get; set; } = new List<Servico>();
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
        public Unidade()
        {
        }

        public Unidade(string nome, string endereco, string localizacao, bool ativa)
        {
            Nome = nome;
            Endereco = endereco;
            Localizacao = localizacao;
            Ativa = ativa;
        }

        public void AddVacina(Vacina vacina)
        {
            Vacinas.Add(vacina);
        }

        public void AddServico(Servico servico)
        {
            Servicos.Add(servico);
        }

        public void AddFuncionario(Funcionario funcionario)
        {
            Funcionarios.Add(funcionario);
        }
    }
}
