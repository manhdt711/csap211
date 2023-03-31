using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BusinessObject;

namespace DataAccess
{
    public class OrderDAO
    {
        public static Order GetOrderById(int orderId)
        {
            string sql = "SELECT * FROM [Order] WHERE OrderId = @OrderId";
            SqlParameter parameter = new SqlParameter("@OrderId", SqlDbType.Int);
            parameter.Value = orderId;
            DataTable dt = DbContext.GetDataBySql(sql, parameter);
            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];
            return new Order
            {
                OrderId = Convert.ToInt32(dr["OrderId"]),
                MemberID = Convert.ToInt32(dr["MemberId"]),
                OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                RequiredDate = Convert.ToDateTime(dr["RequiredDate"]),
                ShippedDate = Convert.ToDateTime(dr["ShippedDate"]),
                Freight = Convert.ToDecimal(dr["Freight"])
            };
        }
        public static List<Order> GetAllOrders()
        {
            string sql = "SELECT * FROM [Order]";
            DataTable dt = DbContext.GetDataBySql(sql);

            List<Order> orders = new List<Order>();
            foreach (DataRow dr in dt.Rows)
            {
                orders.Add(new Order
                {
                    OrderId = Convert.ToInt32(dr["OrderId"]),
                    MemberID = Convert.ToInt32(dr["MemberId"]),
                    OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                    RequiredDate = Convert.ToDateTime(dr["RequiredDate"]),
                    ShippedDate = Convert.ToDateTime(dr["ShippedDate"]),
                    Freight = Convert.ToDecimal(dr["Freight"])
                });
            }
            return orders;
        }

        public static void AddOrder(Order order)
        {
            try
            {
                // Insert new order
                string sql = "INSERT INTO [Order] (MemberId, OrderDate, RequiredDate, ShippedDate, Freight) VALUES (@MemberId, @OrderDate, @RequiredDate, @ShippedDate, @Freight)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@MemberId", SqlDbType.Int) { Value = order.MemberID },
                new SqlParameter("@OrderDate", SqlDbType.DateTime) { Value = order.OrderDate },
                new SqlParameter("@RequiredDate", SqlDbType.DateTime) { Value = order.RequiredDate },
                new SqlParameter("@ShippedDate", SqlDbType.DateTime) { Value = order.ShippedDate },
                new SqlParameter("@Freight", SqlDbType.Money) { Value = order.Freight }
                };
                DbContext.UpdateDataBySql(sql, parameters);
            }
            catch (Exception ex)
            {
                // Handle the exception here, e.g. log the error and/or show an error message to the user
                Console.WriteLine("Error adding order: " + ex.Message);
            }
        }

        public static void UpdateOrder(Order order)
        {
            try
            {
                string sql = "UPDATE [Order] SET MemberId=@MemberId, OrderDate=@OrderDate, RequiredDate=@RequiredDate, ShippedDate=@ShippedDate, Freight=@Freight WHERE OrderId=@OrderId";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@MemberId", SqlDbType.Int) { Value = order.MemberID },
                new SqlParameter("@OrderDate", SqlDbType.DateTime) { Value = order.OrderDate },
                new SqlParameter("@RequiredDate", SqlDbType.DateTime) { Value = order.RequiredDate },
                new SqlParameter("@ShippedDate", SqlDbType.DateTime) { Value = order.ShippedDate },
                new SqlParameter("@Freight", SqlDbType.Money) {Value = order.Freight },
                new SqlParameter("@OrderId", SqlDbType.Int) {Value = order.OrderId }
                };
                DbContext.UpdateDataBySql(sql, parameters);

            }
            catch (Exception ex)
            {
                // log the error and throw a custom exception
                string errorMessage = $"An error occurred while updating the member with ID {order.OrderId}: {ex.Message}";
                throw new Exception(errorMessage);
            }
        }
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
                        MemberID = (int)row["MemberId"],
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