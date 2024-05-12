using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuartosController : ControllerBase
    {
        private readonly QuartoService _quartoService;

        public QuartosController(QuartoService quartoService)
        {
            _quartoService = quartoService;
        }

        [HttpPost]
        public IActionResult CriarQuarto([FromBody] Quarto quarto)
        {
            _quartoService.CriarQuarto(quarto);
            return Ok("Quarto criado com sucesso.");
        }
    }
}
