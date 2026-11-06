using MudEstoque.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MudEstoque.Models
{
    public class MovimentacaoEstoque
    {
        [Key] public int Id { get; set; }

        // N:1 com Produto
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        public TipoMovimentacao TipoMovimentacao { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeAnterior { get; set; }
        public int QuantidadeAtual { get; set; }
        [MaxLength(500)]
        public string? Observacao { get; set; }
        public DateTime DataMovimentacao { get; set; } = DateTime.Now;
    }
}