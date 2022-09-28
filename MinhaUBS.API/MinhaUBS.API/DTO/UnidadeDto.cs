using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaUBS.API.DTO
{
    public class UnidadeDto
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Localizacao { get; set; }
        public bool Ativa { get; set; }
    }

    public class UnidadeUpdate
    {
        public int IDUnidade { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Localizacao { get; set; }
        public bool Ativa { get; set; }
    }

    public class UnidadeVacinaRequest
    {
        public int IDUnidade { get; set; }
        public int IDVacina { get; set; }
    }

    public class UnidadeServicoRequest
    {
        public int IDUnidade { get; set; }
        public int IDServico { get; set; }
    }
}
