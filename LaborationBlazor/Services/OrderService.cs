using LaborationBlazor.Data;
using LaborationBlazor.Models;
using Microsoft.EntityFrameworkCore;
using SharedClasses;

namespace LaborationBlazor.Services;

public class OrderService
{
    private readonly ApplicationDbContext _context;

    public OrderService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateOrder(Order order, List<OrderItem> orderItems)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        foreach (var item in orderItems)
        {
            item.OrderId = order.OrderId;
        }

        _context.OrderItems.AddRange(orderItems);
        await _context.SaveChangesAsync();

        return order.OrderId;
    }

    public async Task<OrderDTO?> GetOrderDetails(int orderId)
    {
        var order = await _context.Orders
                        .Where(o => o.OrderId == orderId)
                        .Include(o => o.OrderItems)
                            .ThenInclude(oi => oi.Product)
                        .Select(o => new OrderDTO
                        {
                            OrderId = o.OrderId,
                            UserName = o.User.UserName,
                            OrderDate = o.OrderDate,
                            TotalPrice = o.TotalPrice,
                            CustomerFirstName = o.CustomerFirstName,
                            CustomerLastName = o.CustomerLastName,
                            CustomerCity = o.CustomerCity,
                            CustomerAddress = o.CustomerAddress,
                            CustomerPhone = o.CustomerPhone,
                            CustomerEmail = o.CustomerEmail,
                            OrderItems = o.OrderItems.Select(oi => new OrderItemDTO
                            {
                                OrderItemId = oi.OrderItemId,
                                ProductName = oi.Product.Name,
                                Quantity = oi.Quantity,
                                PricePerUnit = oi.PricePerUnit
                            }).ToList()
                        })
                        .FirstOrDefaultAsync();
        return order;
    }

}
