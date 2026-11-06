using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudEstoque.Models
{
    public class Estoque
    {
        [Key]
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        public int QuantidadeAtual { get; set; }
        public int EstoqueMinimo { get; set; }
        public int EstoqueMaximo { get; set; } = 9999;
        [MaxLength(100)]
        public string? Localizacao { get; set; }
        public DateTime UltimaAtualizacao { get; set; } = DateTime.Now;

        [NotMapped]
        public bool EstaBaixo => QuantidadeAtual < EstoqueMinimo;
    }
}