using eCommerceMVC.Models;

namespace eCommerceCore.Interfaces
{
    public interface IProductService
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProducts();

        void AddProduct(Product product);
        void UpdateProduct(Product product);
        int DeleteProduct(int id);
    }
}
