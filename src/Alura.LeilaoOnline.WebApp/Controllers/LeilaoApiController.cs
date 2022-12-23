using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Dados.EfCore;
using Alura.LeilaoOnline.WebApp.Services;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        IAdminService service;

        public LeilaoApiController(IAdminService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = service.ConsultaLeiloes();
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = service.ConsultaLeilaoPorId(id);
            if (leilao == null) return NotFound();
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            service.CadastraLeilao(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            if(service.ConsultaLeilaoPorId (leilao.Id)== null) return NotFound();
            service.ModificaLeilao(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = service.ConsultaLeilaoPorId(id);
            if (leilao == null) return NotFound();
            service.RemoveLeilao(leilao);
            return NoContent();
        }

        [HttpPost("{id}/pregao")]
        public IActionResult EndpointIniciaPregao(int id)
        {
            var leilao = service.ConsultaLeilaoPorId(id);
            if (leilao == null) return NotFound();
            service.IniciaPregaoDoLeilaoComId(id);
            return Ok();
        }

        [HttpDelete("{id}/pregao")]
        public IActionResult EndpointFinalizaPregao(int id)
        {
            var leilao = service.ConsultaLeilaoPorId(id);
            if (leilao == null) return NotFound();
            service.FinalizaPregaoDoLeilaoComId(id);
            return Ok();
        }
    }
}
