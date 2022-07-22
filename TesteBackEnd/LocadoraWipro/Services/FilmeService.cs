using LocadoraWipro.Data;
using LocadoraWipro.Services.Contracts;
using WiproTest.LocadoraData.Models;

namespace LocadoraWipro.Services
{
    public class FilmeService: IFilmeService
    {
        private readonly LocadoraContext _context;
        public FilmeService(LocadoraContext context)
        {
            _context = context;
        }
        public void AddFilme(string nomeFilme)
        {
            var filme = new Filme { NomeFilme = nomeFilme, Alugado = false };
            _context.Add<Filme>(filme);
            _context.SaveChanges();
        }

        public List<Filme> GetFilmes()
        {
            List<Filme> filmes = _context.Filmes.Where(f => f.Alugado != true).ToList();
            
            return filmes;
        }
        public string GetFilmeById(int filmeId)
        {
            var filmes = _context.Filmes.Find(filmeId);
            
            return filmes.NomeFilme;
        }

        public void UpdateFilmeStatus(int filmeId, bool alugado = false)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == filmeId);
            filme.Alugado = alugado;
            _context.SaveChanges();
        }

    }
}
