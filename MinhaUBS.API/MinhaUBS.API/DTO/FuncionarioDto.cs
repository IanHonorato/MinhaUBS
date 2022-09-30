namespace MinhaUBS.API.DTO
{
    public class FuncionarioDto
    {
        public int ID_Unidade { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Especialidade { get; set; }
    }
    public class FuncionarioUpdate
    {
        public int ID_Funcionario { get; set; }
        public int ID_Unidade { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Especialidade { get; set; }
    }
}
