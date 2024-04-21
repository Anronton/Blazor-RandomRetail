using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses;

public class OrderDTO
{
    public int OrderId { get; set; }
    public string UserName { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }

    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerEmail { get; set; }

    public List<OrderItemDTO> OrderItems { get; set; }
}
