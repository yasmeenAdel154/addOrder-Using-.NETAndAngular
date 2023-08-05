using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace task.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }

        public int Product1ID { get; set; }
        public int Quantity1 { get; set; }

        public int OrderDetails1ID { get; set; }

        public int Product2ID { get; set; }
        public int Quantity2 { get; set; }

        public int OrderDetails2ID { get; set; }

        public int Product3ID { get; set; }
        public int Quantity3 { get; set; }

        public int OrderDetails3ID { get; set; }
        //public List<OrderDetail> OrderDetails { get; set; }
    }


}