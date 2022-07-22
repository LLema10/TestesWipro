using System.ComponentModel.DataAnnotations;

namespace WiproTest.LocadoraData.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
        public DateTime DataLocacao { get; set; }
    }
}
