using Microsoft.AspNetCore.Mvc;
using MinhaUBS.API.DTO;
using MinhaUBS.API.Interfaces;
using System.Threading.Tasks;

namespace MinhaUBS.API.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;
        public IActionResult Index()
        {
            return View();
        }

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        [Route("funcionarios")]
        public async Task<ActionResult> GetFuncionarios()
        {
            var result = await _funcionarioService.GetFuncionarios();
            return Ok(result);
        }

        [HttpGet]
        [Route("funcionarios/{idFuncionario}")]
        public async Task<ActionResult> GetFuncionarioByID(int idFuncionario)
        {
            var result = await _funcionarioService.GetFuncionarioByID(idFuncionario);
            return Ok(result);
        }

        [HttpPost]
        [Route("funcionarios")]
        public async Task<ActionResult> CreateFuncionario(FuncionarioDto request)
        {
            var result = await _funcionarioService.CreateFuncionario(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("funcionarios")]
        public async Task UpdateFuncionario(FuncionarioUpdate request)
        {
            await _funcionarioService.UpdateFuncionario(request);
        }

        [HttpDelete]
        [Route("funcionarios/{idFuncionario}")]
        public async Task CreateFuncionario(int idFuncionario)
        {
            await _funcionarioService.DeleteFuncionario(idFuncionario);
        }
    }
}
