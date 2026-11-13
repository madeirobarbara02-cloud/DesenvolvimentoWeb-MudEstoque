using Microsoft.EntityFrameworkCore;
using MudEstoque.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudEstoque.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage =" Informe o nome"), MaxLength(100, ErrorMessage ="Use no maximo 100 caracteres")]
        public string Nome { get; set; } = "";
        [MaxLength(500, ErrorMessage ="Use no maximo 500 caracteres")]
        public string? Descricao { get; set; }
        [MaxLength(50, ErrorMessage = "Use no maximo 50 caracteres"), Unicode(false)]
        public string? CodigoBarras { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }

        // N:1 com Categoria: FK + navegação
        [Required(ErrorMessage ="Selecione uma categoria")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        // N:1 com Fornecedor: FK + navegação
        [Required(ErrorMessage = "Selecione um fornecedor")]
        public int FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }

        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
