using eCommerceCore.Interfaces;
using eCommerceCore.Models;
using eCommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceCore.Repository
{
    public class ProductRepository : IProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public int DeleteProduct(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                int count = _dbContext.SaveChanges();
                return count;
            }

            return 0;

        }
    }
}
