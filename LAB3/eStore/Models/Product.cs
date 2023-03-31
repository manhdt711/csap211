using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

#nullable disable

namespace eStore.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Weight { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitslnStock { get; set; }
        public static void DeleteProduct(int productId)
        {
            try
            {
                string sql = "delete from OrderDetail where ProductId=@ProductId DELETE FROM Product WHERE ProductId=@ProductId";
                SqlParameter parameter = new SqlParameter("@ProductId", SqlDbType.Int);
                parameter.Value = productId;
                DbContext.UpdateDataBySql(sql, parameter);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                // For example:
                Console.WriteLine("An error occurred while deleting the Product: " + ex.Message);
                throw; // re-throw the exception to propagate it up the call stack
            }
        }
    }
}
