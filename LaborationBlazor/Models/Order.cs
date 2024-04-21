using LaborationBlazor.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborationBlazor.Models;

public class Order
{
    public int OrderId { get; set; }

    [ForeignKey("ApplicationUser")]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }

    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerEmail { get; set; }


    public List<OrderItem> OrderItems { get; set; }
}
