using System.ComponentModel.DataAnnotations.Schema;

namespace LaborationBlazor.Models;

public class CartProduct
{
    public int CartProductId { get; set; }

    [ForeignKey("Cart")]
    public int CartId { get; set; }
    public Cart Cart { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }
}
