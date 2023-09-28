using GameHall.Model;


namespace GameHall.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(long id);
        Task<IEnumerable<Produto>> GetByNome(string nome);
        Task<Produto> GetByPreco(decimal preco);
        Task<Produto> GetByConsole(string console);
        Task<Produto?> Create(Produto produto);
        Task<Produto> Update(Produto produto);
        Task Delete(Produto produto);

    }
}
