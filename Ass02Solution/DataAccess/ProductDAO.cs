using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BusinessObject;

namespace DataAccess
{
    public class ProductDAO
    {
        public static Product GetProductById(int productId)
        {
            string sql = "SELECT * FROM Product WHERE ProductId = @ProductId";
            SqlParameter parameter = new SqlParameter("@ProductId", SqlDbType.Int);
            parameter.Value = productId;
            DataTable dt = DbContext.GetDataBySql(sql, parameter);
            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];
            return new Product
            {
                ProductId = Convert.ToInt32(dr["ProductId"]),
                CategoryId = Convert.ToInt32(dr["CategoryId"]),
                ProductName = dr["ProductName"].ToString(),
                Weight = dr["Weight"].ToString(),
                UnitPrice = Convert.ToDecimal(dr["UnitPrice"]),
                UnitsInStock = Convert.ToInt32(dr["UnitslnStock"])
            };
        }

        public static List<Product> GetAllProducts()
        {
            string sql = "SELECT * FROM Product";
            DataTable dt = DbContext.GetDataBySql(sql);

            List<Product> products = new List<Product>();
            foreach (DataRow dr in dt.Rows)
            {
                products.Add(new Product
                {
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
                    ProductName = dr["ProductName"].ToString(),
                    Weight = dr["Weight"].ToString(),
                    UnitPrice = Convert.ToDecimal(dr["UnitPrice"]),
                    UnitsInStock = Convert.ToInt32(dr["UnitslnStock"])
                });
            }
            return products;
        }

        public static void AddProduct(Product product)
        {
            try
            {
                // Insert new product
                string sql = "INSERT INTO [Product] (CategoryId, ProductName, Weight, UnitPrice, UnitslnStock) VALUES (@CategoryId, @ProductName, @Weight, @UnitPrice, @UnitsInStock)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CategoryId", SqlDbType.Int) { Value = product.CategoryId },
                    new SqlParameter("@ProductName", SqlDbType.VarChar) { Value = product.ProductName },
                    new SqlParameter("@Weight", SqlDbType.VarChar) { Value = product.Weight },
                    new SqlParameter("@UnitPrice", SqlDbType.Money) { Value = product.UnitPrice },
                    new SqlParameter("@UnitsInStock", SqlDbType.Int) { Value = product.UnitsInStock }
                };
                DbContext.UpdateDataBySql(sql, parameters);
            }
            catch (Exception ex)
            {
                // Handle the exception here, e.g. log the error and/or show an error message to the user
                Console.WriteLine("Error adding product: " + ex.Message);
            }
        }
        public static void UpdateProduct(Product product)
        {
            try
            {
                string sql = "UPDATE Product SET CategoryId=@CategoryId, ProductName=@ProductName, Weight=@Weight, UnitPrice=@UnitPrice, UnitslnStock=@UnitslnStock WHERE ProductId=@ProductId";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@CategoryId", SqlDbType.VarChar) { Value = product.CategoryId },
            new SqlParameter("@ProductName", SqlDbType.VarChar) { Value = product.ProductName },
            new SqlParameter("@Weight", SqlDbType.VarChar) { Value = product.Weight },
            new SqlParameter("@UnitPrice", SqlDbType.VarChar) { Value = product.UnitPrice },
            new SqlParameter("@UnitslnStock", SqlDbType.VarChar) { Value = product.UnitsInStock },
            new SqlParameter("@ProductId", SqlDbType.Int) { Value = product.ProductId }
                };
                DbContext.UpdateDataBySql(sql, parameters);
            }
            catch (Exception ex)
            {
                // log the error and throw a custom exception
                string errorMessage = $"An error occurred while updating the member with ID {product.ProductId}: {ex.Message}";
                throw new Exception(errorMessage);
            }
        }


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
