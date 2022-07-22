using LocadoraWipro.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using WiproTest.LocadoraData.Models;

namespace LocadoraWipro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocacaoController : Controller
    {
        private readonly ILocacaoService _locacaoService;
        private readonly IFilmeService _filmeService;
        private readonly IClienteService _clienteService;
        public LocacaoController(ILocacaoService locacaoService, IFilmeService filmeService, IClienteService clienteService)
        {
            _locacaoService = locacaoService;
            _filmeService = filmeService;
            _clienteService = clienteService;
        }

        [HttpPost]
        [Route("AlugarFilme")]
        public string AlugarFilme(int filmeId, int clienteId)
        {
            List<Filme> filmes = _filmeService.GetFilmes();
            if(!filmes.Contains(filmes.Where(f => f.Id == filmeId).FirstOrDefault())) return $"Este filme já foi alugado";

            _locacaoService.AlugarFilme(clienteId, filmeId , DateTime.Now);
            _filmeService.UpdateFilmeStatus(filmeId, true);

            var clienteName = _clienteService.GetClientById(clienteId);
            var filmeName = _filmeService.GetFilmeById(filmeId);


            return $"O usuário {clienteName} alugou o filme {filmeName}";
        }
        [HttpDelete]
        [Route("DevolverFilme")]
        public string DevolverFilme(int filmeId)
        {
            var registro = _locacaoService.GetLocacoes().Where(r => r.FilmeId == filmeId).FirstOrDefault();

            if (registro == null) return "Este Filme não está  está alugado";

            _filmeService.UpdateFilmeStatus(filmeId, false);
            _locacaoService.DevolverFilme(filmeId);
            
            var atraso = registro.DataLocacao.Subtract(DateTime.Now).TotalDays;

            if (atraso > 2) return "A devolução esta atrasada e sujeita à multa";
            return "Obrigado pela preferência volte sempre";
        }
    }
}
