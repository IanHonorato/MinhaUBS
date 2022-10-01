using Microsoft.AspNetCore.Mvc;
using MinhaUBS.API.DTO;
using MinhaUBS.API.Interfaces;
using System.Threading.Tasks;

namespace MinhaUBS.API.Controllers
{
    public class ServicoController : Controller
    {
        private readonly IServicoService _servicoService; 
        public IActionResult Index()
        {
            return View();
        }

        public ServicoController(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        [HttpGet]
        [Route("servicos")]
        public async Task<ActionResult> GetServicos()
        {
            var result = await _servicoService.GetServicos();
            return Ok(result);
        }

        [HttpGet]
        [Route("servicos/{idServicos}")]
        public async Task<ActionResult> GetServicoByID(int idServico)
        {
            var result = await _servicoService.GetServicoByID(idServico);
            return Ok(result);
        }

        [HttpPost]
        [Route("servicos")]
        public async Task<ActionResult> CreateServico(ServicoDto request)
        {
            var result = await _servicoService.CreateServico(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("servicos")]
        public async Task UpdateServico(ServicoUpdate request)
        {
            await _servicoService.UpdateServico(request);
        }

        [HttpDelete]
        [Route("servicos/{idServico}")]
        public async Task CreateServico(int idServico)
        {
            await _servicoService.DeleteServico(idServico);
        }

        [HttpGet]
        [Route("servicos/{idServico}/unidades")]
        public async Task GetUnidadesComServico(int idServico)
        {
            await _servicoService.GetUnidadesComServico(idServico);
        }
    }
}
