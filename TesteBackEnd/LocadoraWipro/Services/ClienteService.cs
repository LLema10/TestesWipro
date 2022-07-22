using LocadoraWipro.Data;
using LocadoraWipro.Services.Contracts;
using WiproTest.LocadoraData.Models;

namespace LocadoraWipro.Services
{
    public class ClienteService : IClienteService
    {
        private readonly LocadoraContext _context;
        public ClienteService(LocadoraContext context)
        {
            _context = context;
        }

        public void CadastraCliente (string nomeCliente)
        {
            var newCLiente = new Cliente { NomeCliente = nomeCliente };
            _context.Add<Cliente>(newCLiente);
            _context.SaveChanges();
        }

        public List<Cliente> GetCliente()
        {
            var clientes = _context.Clientes.ToList();
            
            return clientes; 
        }

        public string GetClientById(int clientId)
        {
            var cliente = _context.Clientes.Find(clientId);

            return cliente.NomeCliente;
        }

    }
}
