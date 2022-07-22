using WiproTest.LocadoraData.Models;

namespace LocadoraWipro.Services.Contracts
{
    public interface ILocacaoService
    {
        List<Locacao> GetLocacoes();
        void AlugarFilme(int clientId, int filmeId, DateTime dateLocacao);

        void DevolverFilme(int filmeId);
    }
}
