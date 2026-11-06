using System.ComponentModel.DataAnnotations;

namespace MudEstoque.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Nome { get; set; } = "";
        [MaxLength(500)]
        public string? Descricao { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<Produto> Produtos { get; set; } = [];
    }
}
