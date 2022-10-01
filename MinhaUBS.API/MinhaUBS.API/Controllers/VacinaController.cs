using Microsoft.AspNetCore.Mvc;
using MinhaUBS.API.DTO;
using MinhaUBS.API.Interfaces;
using System.Threading.Tasks;

namespace MinhaUBS.API.Controllers
{
    public class VacinaController : Controller
    {
        private readonly IVacinaService _vacinaService;
        public IActionResult Index()
        {
            return View();
        }
        public VacinaController(IVacinaService vacinaService)
        {
            _vacinaService = vacinaService;
        }

        [HttpGet]
        [Route("vacinas")]
        public async Task<ActionResult> GetVacinas()
        {
            var result = await _vacinaService.GetVacinas();
            return Ok(result);
        }

        [HttpGet]
        [Route("vacinas/{idVacina}")]
        public async Task<ActionResult> GetVacinaByID(int idVacina)
        {
            var result = await _vacinaService.GetVacinasByID(idVacina);
            return Ok(result);
        }

        [HttpPost]
        [Route("vacinas")]
        public async Task<ActionResult> CreateVacina(VacinaDto request)
        {
            var result = await _vacinaService.CreateVacina(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("vacinas")]
        public async Task UpdateVacina(VacinaUpdate request)
        {
            await _vacinaService.UpdateVacina(request);
        }

        [HttpDelete]
        [Route("vacinas/{idVacinas}")]
        public async Task CreateVacina(int idVacina)
        {
            await _vacinaService.DeleteVacina(idVacina);
        }

        [HttpGet]
        [Route("vacinas/{idVacinas}/unidades")]
        public async Task GetUnidadesComVacina(int idVacina)
        {
            await _vacinaService.GetUnidadesComVacina(idVacina);
        }
    }
}
