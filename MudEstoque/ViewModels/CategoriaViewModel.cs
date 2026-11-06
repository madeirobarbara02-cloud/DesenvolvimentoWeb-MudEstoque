using MudEstoque.Models;
using System.ComponentModel.DataAnnotations;

namespace MudEstoque.ViewModels
{
    // Dados do formulário de categoria: o que a tela edita e como valida
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome.")]
        [MaxLength(100, ErrorMessage = "Use no máximo 100 caracteres.")]
        public string Nome { get; set; } = "";

        [MaxLength(500, ErrorMessage = "Use no máximo 500 caracteres.")]
        public string? Descricao { get; set; }

        public bool Ativo { get; set; } = true;

        // Id 0 = inclusão; outro valor = edição
        public bool EmEdicao => Id != 0;

        // Copia os dados da entidade para o formulário (edição)
        //Vai do banco de dados para a tela(Processo de edição do registro)
        public static CategoriaViewModel DaEntidade(Categoria categoria)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();
            viewModel.Id = categoria.Id;
            viewModel.Nome = categoria.Nome;
            viewModel.Descricao = categoria.Descricao;
            viewModel.Ativo = categoria.Ativo;
            return viewModel;
        }

        //Vai da tela para o banco para salvar oque acabou de ser preenchido
        // Monta a entidade que vai para o serviço
        public Categoria ParaEntidade()
        {
            Categoria categoria = new Categoria();
            categoria.Id = Id;
            categoria.Nome = Nome.Trim();
            categoria.Descricao = TextoOuNulo(Descricao);
            categoria.Ativo = Ativo;
            return categoria;
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