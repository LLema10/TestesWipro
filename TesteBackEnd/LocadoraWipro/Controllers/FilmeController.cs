using LocadoraWipro.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using WiproTest.LocadoraData.Models;

namespace LocadoraWipro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : Controller
    {
        private readonly IFilmeService _filmeService;
        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        public List<Filme> GetFilmes()
        {
            return _filmeService.GetFilmes();
        }


        [HttpPost]
        [Route("CadastrarFilme")]
        public string AdicionaFilme(string nomeFilme)
        {
            _filmeService.AddFilme(nomeFilme);

            return "Filme registrado com sucesso";
        }
    }
}