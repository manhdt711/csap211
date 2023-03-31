using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

#nullable disable

namespace eStore.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? MemberId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }

        public virtual Member Member { get; set; }

        public static void DeleteOrder(int OrderID)
        {
            try
            {
                string sql = " delete from OrderDetail where OrderId = @OrderId   delete from [Order] where OrderId = @OrderId";
                SqlParameter parameter = new SqlParameter("@OrderId", SqlDbType.Int);
                parameter.Value = OrderID;
                DbContext.UpdateDataBySql(sql, parameter);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                // For example:
                Console.WriteLine("An error occurred while deleting the Order: " + ex.Message);
                throw; // re-throw the exception to propagate it up the call stack
            }
        }
        public static List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Order> orders = new List<Order>();
            try
            {
                string sql = "SELECT * FROM [Order] WHERE OrderDate >= @StartDate AND OrderDate <= @EndDate ORDER BY OrderDate DESC";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = startDate },
            new SqlParameter("@EndDate", SqlDbType.DateTime) { Value = endDate }
                };
                DataTable table = DbContext.GetDataBySql(sql, parameters);
                foreach (DataRow row in table.Rows)
                {
                    Order order = new Order()
                    {
                        OrderId = (int)row["OrderId"],
                        MemberId = (int)row["MemberId"],
                        OrderDate = (DateTime)row["OrderDate"],
                        RequiredDate = (DateTime)row["RequiredDate"],
                        ShippedDate = (DateTime)row["ShippedDate"],
                        Freight = (decimal)row["Freight"]
                    };
                    orders.Add(order);
                }
            }
            catch (Exception ex)
            {
                // log the error and throw a custom exception
                string errorMessage = $"An error occurred while retrieving orders between {startDate} and {endDate}: {ex.Message}";
                throw new Exception(errorMessage);
            }
            return orders;
        }
    }
}
