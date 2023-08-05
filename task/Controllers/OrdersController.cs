using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using task.Models;

namespace task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        string ConnectionString = "Server = localhost\\SQLEXPRESS;" +
            " Database = Orders; Trusted_Connection = true; encrypt = false";

        [HttpPost]
        public IActionResult PostOrder(Order order)
        {
            Console.WriteLine(order.ToJson());
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("AddOrderAndOrderDetails", connection);
                command.CommandType = CommandType.StoredProcedure;

                var orderIDParam = new SqlParameter("@OrderID", SqlDbType.Int);
                orderIDParam.Value = order.OrderID;
                command.Parameters.Add(orderIDParam);

                var customerIDParam = new SqlParameter("@CustomerID", SqlDbType.Int);
                customerIDParam.Value = order.CustomerID;
                command.Parameters.Add(customerIDParam);

                var orderDateParam = new SqlParameter("@OrderDate", SqlDbType.DateTime);
                orderDateParam.Value = order.OrderDate;
                command.Parameters.Add(orderDateParam);

                //int i = 1;

                //foreach (var orderDetail in order.OrderDetails)
                //{
                //var orderdeDetailedIDParam = new SqlParameter("@OrderDetailID" + i, SqlDbType.Int);
                //orderdeDetailedIDParam.Value = orderDetail.OrderDetailID;
                //command.Parameters.Add(orderdeDetailedIDParam);

                ////var orderedIDForProductParam = new SqlParameter("@OrderID" + i, SqlDbType.Int);
                ////orderedIDForProductParam.Value = order.OrderID;
                ////command.Parameters.Add(orderedIDForProductParam);

                //var productIDParam = new SqlParameter("@ProductID" + i, SqlDbType.Int);
                //productIDParam.Value = orderDetail.ProductID;
                //command.Parameters.Add(productIDParam);

                //var quantityParam = new SqlParameter("@Quantity" + i, SqlDbType.Int);
                //quantityParam.Value = orderDetail.Quantity;
                //command.Parameters.Add(quantityParam);
                //    i++;
                //}

                /* 1 */

                var orderdeDetailedIDParam = new SqlParameter("@OrderDetailID1" , SqlDbType.Int);
                orderdeDetailedIDParam.Value = order.OrderDetails1ID;
                command.Parameters.Add(orderdeDetailedIDParam);

                //var orderedIDForProductParam = new SqlParameter("@OrderID" + i, SqlDbType.Int);
                //orderedIDForProductParam.Value = order.OrderID;
                //command.Parameters.Add(orderedIDForProductParam);

                var productIDParam = new SqlParameter("@ProductID1" , SqlDbType.Int);
                productIDParam.Value = order.Product1ID;
                command.Parameters.Add(productIDParam);

                var quantityParam = new SqlParameter("@Quantity1" , SqlDbType.Int);
                quantityParam.Value = order.Quantity1;
                command.Parameters.Add(quantityParam);

                /* 2 */

                 orderdeDetailedIDParam = new SqlParameter("@OrderDetailID2", SqlDbType.Int);
                orderdeDetailedIDParam.Value = order.OrderDetails2ID;
                command.Parameters.Add(orderdeDetailedIDParam);

                //var orderedIDForProductParam = new SqlParameter("@OrderID" + i, SqlDbType.Int);
                //orderedIDForProductParam.Value = order.OrderID;
                //command.Parameters.Add(orderedIDForProductParam);

                 productIDParam = new SqlParameter("@ProductID2", SqlDbType.Int);
                productIDParam.Value = order.Product2ID;
                command.Parameters.Add(productIDParam);

                 quantityParam = new SqlParameter("@Quantity2", SqlDbType.Int);
                quantityParam.Value = order.Quantity2;
                command.Parameters.Add(quantityParam);

                /* 3 */

                orderdeDetailedIDParam = new SqlParameter("@OrderDetailID3", SqlDbType.Int);
                orderdeDetailedIDParam.Value = order.OrderDetails3ID;
                command.Parameters.Add(orderdeDetailedIDParam);

                //var orderedIDForProductParam = new SqlParameter("@OrderID" + i, SqlDbType.Int);
                //orderedIDForProductParam.Value = order.OrderID;
                //command.Parameters.Add(orderedIDForProductParam);

                productIDParam = new SqlParameter("@ProductID3", SqlDbType.Int);
                productIDParam.Value = order.Product3ID;
                command.Parameters.Add(productIDParam);

                quantityParam = new SqlParameter("@Quantity3", SqlDbType.Int);
                quantityParam.Value = order.Quantity3;
                command.Parameters.Add(quantityParam);



                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return BadRequest();
                }

                
            }

            return Ok();
        }
    }
}
