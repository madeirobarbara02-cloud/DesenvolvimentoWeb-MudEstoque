using MudEstoque.Models;

namespace MudEstoque.Services.Interfaces
{
    // Contrato do cadastro de fornecedores: o que a tela pode pedir
    public interface IFornecedorService
    {
        // Estes tasks são CRUD (Create, Search, Update, Delete)
        // Lista todos os fornecedores em ordem alfabética por razão social
        Task<IEnumerable<Fornecedor>> ListarTodosAsync();

        // Busca um fornecedor pelo Id; devolve null quando não existe
        Task<Fornecedor?> ObterPorIdAsync(int id);

        // Inclui o fornecedor e devolve o Id gerado pelo banco
        Task<int> AdicionarAsync(Fornecedor fornecedor);

        // Altera o fornecedor; devolve false quando o Id não existe
        Task<bool> AlterarAsync(Fornecedor fornecedor);

        // Exclui o fornecedor; devolve false quando o Id não existe
        Task<bool> ExcluirAsync(int id);
    }
}
