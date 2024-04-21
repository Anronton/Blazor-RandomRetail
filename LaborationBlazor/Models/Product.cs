namespace LaborationBlazor.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImgUrl { get; set; }
    public int Quantity { get; set; }
    public bool IsOnSale { get; set; } = false;

    //public List<CartProduct> CartProducts { get; set; }
}
