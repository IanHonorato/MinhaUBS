using Microsoft.AspNetCore.Mvc;
using MinhaUBS.API.DTO;
using MinhaUBS.API.Interfaces;
using MinhaUBS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaUBS.API.Controllers
{
    public class UnidadeController : Controller
    {
        private readonly IUnidadeService _unidadeService;
        public IActionResult Index()
        {
            return View();
        }

        public UnidadeController(IUnidadeService unidadeService)
        {
            _unidadeService = unidadeService;
        }

        [HttpGet]
        [Route("unidades")]
        public async Task<ActionResult> GetUnidades()
        {
            var result = await _unidadeService.GetUnidades();
            return Ok(result);
        }

        [HttpGet]
        [Route("unidades/{idUnidade}")]
        public async Task<ActionResult> GetUnidadesByID( int idUnidade)
        {
            var result = await _unidadeService.GetUnidadesByID(idUnidade);
            return Ok(result);
        }

        [HttpGet]
        [Route("unidades/ativas")]
        public async Task<ActionResult> GetUnidadesAtivas()
        {
            var result = await _unidadeService.GetUnidadesAtivas();
            return Ok(result);
        }

        [HttpGet]
        [Route("unidades/{idUnidade}/vacinas")]
        public async Task<ActionResult> GetVacinasNaUnidade(int idUnidade)
        {
            var result = await _unidadeService.GetVacinasDaUnidade(idUnidade);
            return Ok(result);
        }

        [HttpPost]
        [Route("unidades")]
        public async Task<ActionResult> CreateUnidade(UnidadeDto request)
        {
            var result = await _unidadeService.CreateUnidade(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("unidades")]
        public async Task UpdateUnidade(UnidadeUpdate request)
        {
            await _unidadeService.UpdateUnidade(request);
        }

        [HttpDelete]
        [Route("unidades/{idUnidade}")]
        public async Task CreateUnidade(int idUnidade)
        {
            await _unidadeService.DeleteUnidade(idUnidade);
        }

        [HttpPost]
        [Route("unidades/{idUnidade}/vacina/{idVacina}")]
        public async Task AdicionarVacinaNaUnidade(int idUnidade, int idVacina)
        {
            await _unidadeService.AdicionarVacinaNaUnidade(idUnidade, idVacina);
        }

        [HttpPost]
        [Route("unidades/{idUnidade}/servico/{idServico}")]
        public async Task AdicionarServicoNaUnidade(int idUnidade, int idServico)
        {
            await _unidadeService.AdicionarServicoNaUnidade(idUnidade, idServico);
        }
    }
}
