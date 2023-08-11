using GeekShopping.ProductApi.Data.ValueObjects;

namespace GeekShopping.ProductApi.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProductVO>> FindAll();
    }
}
