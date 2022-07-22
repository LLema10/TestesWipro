using WiproTest.LocadoraData.Models;

namespace LocadoraWipro.Services.Contracts
{
    public interface IFilmeService
    {
        void AddFilme(string nomeFilme);
        List<Filme> GetFilmes();
        string GetFilmeById(int filmeId);
        void UpdateFilmeStatus(int filmeId, bool alugado = false);
    }
}
