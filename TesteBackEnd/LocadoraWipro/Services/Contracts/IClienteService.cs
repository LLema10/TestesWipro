using WiproTest.LocadoraData.Models;

namespace LocadoraWipro.Services.Contracts
{
    public interface IClienteService
    {
        void CadastraCliente(string nomeCliente);

        public List<Cliente> GetCliente();

        string GetClientById(int clientId);
    }
}
