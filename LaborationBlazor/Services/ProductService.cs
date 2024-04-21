using LaborationBlazor.Data;
using LaborationBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LaborationBlazor.Services;

public class ProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        List<Product> products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task<Product> GetProductById(int id)
    {
        var result = await _context.Products.FindAsync(id);
        return result;
    }

    public async Task UpdateProductQuantity(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
}
