using LaborationBlazor.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborationBlazor.Models;

public class Cart
{
    public int CartId { get; set; }

    [ForeignKey("ApplicationUser")]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    public List<CartProduct> CartProducts { get; set; }
}
