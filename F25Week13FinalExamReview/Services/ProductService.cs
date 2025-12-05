using F25Week13FinalExamReview.Data;
using F25Week13FinalExamReview.Models;
using Microsoft.EntityFrameworkCore;

namespace F25Week13FinalExamReview.Services
{
    public class ProductService
    {
        private readonly ProductContext _context;

        public ProductService(ProductContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Product>> GetProductsAsync(string searchKeyword = null)
        {
            // get all products
            var products = _context.Products
                                   .Include(p => p.Category)
                                   .AsQueryable();

            // get products by name
            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                products = products.Where(p => p.ProductName.Contains(searchKeyword));
            }

            return await products.ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int catId)
        {
            // get all products
            var products = _context.Products
                                   .Include(p => p.Category)
                                   .AsQueryable();

            // if category is selected
            if (catId > 0)
                products = products.Where(p => p.CategoryId == catId);

            return await products.ToListAsync();
        }
    }
}
