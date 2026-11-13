using MudEstoque.Models;
using System.ComponentModel.DataAnnotations;

namespace MudEstoque.ViewModels
{
    public class FornecedorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a razão social.")]
        [MaxLength(200, ErrorMessage = "Use no máximo 200 caracteres.")]
        public string RazaoSocial { get; set; } = "";

        [Required(ErrorMessage = "Informe o CNPJ.")]
        [MaxLength(18, ErrorMessage = "Use no máximo 18 caracteres.")]
        public string CNPJ { get; set; } = "";

        // RegularExpression aceita vazio (o campo é opcional); [EmailAddress] rejeitaria ""
        [MaxLength(200, ErrorMessage = "Use no máximo 200 caracteres.")]
        [RegularExpression(@"^$|^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Informe um e-mail válido.")]
        public string? Email { get; set; }

        [MaxLength(20, ErrorMessage = "Use no máximo 20 caracteres.")]
        public string? Telefone { get; set; }

        [MaxLength(300, ErrorMessage = "Use no máximo 300 caracteres.")]
        public string? Endereco { get; set; }

        public bool Ativo { get; set; } = true;

        // Id 0 = inclusão; outro valor = edição
        public bool EmEdicao => Id != 0;

        // Banco -> tela (edição)
        public static FornecedorViewModel DaEntidade(Fornecedor fornecedor)
        {
            return new FornecedorViewModel
            {
                Id = fornecedor.Id,
                RazaoSocial = fornecedor.RazaoSocial,
                CNPJ = fornecedor.CNPJ,
                Email = fornecedor.Email,
                Endereco = fornecedor.Endereco,
                Telefone = fornecedor.Telefone,
                Ativo = fornecedor.Ativo
            };
        }

        // Tela -> Banco para salvar o que foi preenchido
        public Fornecedor ParaEntidade()
        {
            return new Fornecedor
            {
                Id = Id,
                RazaoSocial = RazaoSocial.Trim(),
                CNPJ = CNPJ.Trim(),
                Email = TextoOuNulo(Email),
                Endereco = TextoOuNulo(Endereco),
                Telefone = TextoOuNulo(Telefone),
                Ativo = Ativo
            };
        }

        // Texto em branco vira null: o banco guarda NULL, não ""
        private static string? TextoOuNulo(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return null;
            }

            return texto.Trim();
        }
    }
}
