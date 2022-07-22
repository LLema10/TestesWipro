using LocadoraWipro.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using WiproTest.LocadoraData.Models;

namespace LocadoraWipro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public List<Cliente> GetCliente()
        {
            return _clienteService.GetCliente();
        }


        [HttpPost]
        [Route("CadastrarCliente")]
        public string AdicionaCliente(string nomeCliente)
        {
            nomeCliente = nomeCliente.ToUpper();
            var clientesCadastrados = _clienteService.GetCliente();
            foreach (var cliente in clientesCadastrados)
            {
                if (cliente.NomeCliente.ToUpper() == nomeCliente) return $"Já existe um cliente com esse nome, favor modifique ou tente outro.";
            }

            _clienteService.CadastraCliente(nomeCliente);

            return $"Cliente {nomeCliente} registrado(a) com sucesso";
        }
    }
}