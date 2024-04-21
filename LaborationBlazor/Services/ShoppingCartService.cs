using LaborationBlazor.Data;
using LaborationBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LaborationBlazor.Services;

public class ShoppingCartService
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ShoppingCartService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    private string GetCurrentUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId is null)
        {
            throw new Exception("User is not authenticated");
        }
        return userId;
    }

    public async Task AddToCart(Product product, int quantity = 1)
    {
        var userId = GetCurrentUserId();
        var userCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        if (userCart == null)
        {
            throw new Exception("No cart found for the current user");
        }

        var cartProduct = await _context.CartProducts
                            .FirstOrDefaultAsync(cp => cp.CartId == userCart.CartId && cp.ProductId == product.Id);

        if (cartProduct is null)
        {
            cartProduct = new CartProduct
            {
                CartId = userCart.CartId,
                ProductId = product.Id,
                Quantity = quantity
            };
            _context.CartProducts.Add(cartProduct);
        }
        else
        {
            cartProduct.Quantity = quantity;
        }
        await _context.SaveChangesAsync();
    }

    public async Task<List<CartProduct>> GetCartItems()
    {
        var userId = GetCurrentUserId();
        var userCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        if(userCart is null)
        {
            throw new Exception("No cart found for the current user");
        }


        var cartProducts = await _context.CartProducts
                            .Where(cp => cp.CartId == userCart.CartId)
                            .Include(cp => cp.Product)
                            .ToListAsync();

        return cartProducts;
    }

    public async Task RemoveFromCart(int productId)
    {
        var userId = GetCurrentUserId();
        var userCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        if (userCart is null)
        {
            throw new Exception("No cart found for the current user");
        }

        var cartProduct = await _context.CartProducts
                            .FirstOrDefaultAsync(cp => cp.CartId == userCart.CartId && cp.ProductId == productId);

        if (cartProduct is not null)
        {
            _context.CartProducts.Remove(cartProduct);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateCartProductQuantity(int productId, int newQuantity) 
    {
        var userId = GetCurrentUserId();
        var userCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        if (userCart is null)
        {
            throw new Exception("No cart found for the current user");
        }

        var cartProduct = await _context.CartProducts
                            .FirstOrDefaultAsync(cp => cp.CartId == userCart.CartId && cp.ProductId == productId);

        if (cartProduct is not null)
        {
            cartProduct.Quantity = newQuantity;
            await _context.SaveChangesAsync();
        }

    }

    public async Task RemoveAllFromCart() 
    {
        var userId = GetCurrentUserId();
        var userCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        if (userCart is null)
        {
            throw new Exception("No cart found for the current user");
        }

        var cartProducts = await _context.CartProducts
                                .Where(cp => cp.CartId == userCart.CartId)
                                .ToListAsync();

        _context.CartProducts.RemoveRange(cartProducts);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveSoldOutProducts()
    {
        var userId = GetCurrentUserId();
        var userCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        if (userCart == null)
        {
            throw new Exception("No cart found for the current user");
        }

        var unavailableCartProducts = await _context.CartProducts
                                .Where(cp => cp.CartId == userCart.CartId && cp.Product.Quantity <= 0)
                                .ToListAsync();

        _context.CartProducts.RemoveRange(unavailableCartProducts);
        await _context.SaveChangesAsync();
    }
}
