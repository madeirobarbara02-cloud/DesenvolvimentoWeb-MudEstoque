using MudEstoque.Models;

namespace MudEstoque.Services.Interfaces
{
    // Contrato do cadastro de categorias: o que a tela pode pedir
    public interface ICategoriaService
    {
        // Estes tasks são CRUD (Create, Search, Update, Delete)
        // Lista todas as categorias em ordem alfabética
        Task<IEnumerable<Categoria>> ListarTodosAsync();

        // Busca uma categoria pelo Id; devolve null quando não existe
        Task<Categoria?> ObterPorIdAsync(int id);

        // Inclui a categoria e devolve o Id gerado pelo banco
        Task<int> AdicionarAsync(Categoria categoria);

        // Altera a categoria; devolve false quando o Id não existe
        Task<bool> AlterarAsync(Categoria categoria);

        // Exclui a categoria; devolve false quando o Id não existe
        Task<bool> ExcluirAsync(int id);
    }
}