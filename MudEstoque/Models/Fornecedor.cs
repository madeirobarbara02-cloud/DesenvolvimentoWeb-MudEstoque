using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudEstoque.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        [Column("Razao Social")]
        public string RazaoSocial { get; set; } = "";

        [Required, MaxLength(18)]
        public string CNPJ { get; set; } = "";

        [NotMapped]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? Telefone { get; set; }

        [MaxLength(300)]
        public string? Endereco { get; set; }

        public bool Ativo { get; set; } = true;

        public ICollection<Produto> Produtos { get; set; } = [];
    }
}
