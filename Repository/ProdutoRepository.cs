namespace Coursera.Repository;

using Coursera.Models;

public static class ProdutoRepository
{
    private static List<Produto> _produtos = new List<Produto>();
    private static int _nextId = 1;

    public static List<Produto> GetAll() => _produtos;

    public static Produto? GetById(int id) => _produtos.FirstOrDefault(p => p.Id == id);

    public static Produto Add(Produto produto)
    {
        produto.Id = _nextId++;
        _produtos.Add(produto);
        return produto;
    }

    public static void Update(Produto produto)
    {
        var index = _produtos.FindIndex(p => p.Id == produto.Id);
        if (index == -1) return;
        _produtos[index] = produto;
    }

    public static void Delete(int id)
    {
        var produto = GetById(id);
        if (produto != null)
            _produtos.Remove(produto);
    }
}
