using LocadoraWipro.Data;
using LocadoraWipro.Services.Contracts;
using WiproTest.LocadoraData.Models;

namespace LocadoraWipro.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly LocadoraContext _context;
        public LocacaoService(LocadoraContext context)
        {
            _context = context;
        }
        public List<Locacao> GetLocacoes()
        {
            return _context.Locacoes.ToList();
        }
        public void AlugarFilme(int clientId,int filmeId, DateTime dateLocacao)
        {
            var filme = new Locacao { ClienteId = clientId, FilmeId = filmeId, DataLocacao = dateLocacao };
            _context.Add<Locacao>(filme);
            _context.SaveChanges();
        }

        public void DevolverFilme(int filmeId)
        {
            var query = _context.Locacoes.Where(f => f.FilmeId == filmeId).FirstOrDefault();
            if(query != null)
            {
                _context.Locacoes.Remove(query);
                _context.SaveChanges();
            }
            
        }
    }
}
