using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        public static List<OrderDetail> GetOrderbyMemberID(int memberId)
        {
            string sql = "SELECT * FROM OrderDetail WHERE OrderId IN (SELECT OrderId FROM [Order] WHERE MemberId = @MemberID)";
            SqlParameter parameter = new SqlParameter("@MemberID", DbType.Int32);
            parameter.Value = memberId;
            DataTable dt = DbContext.GetDataBySql(sql, parameter);
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (DataRow dr in dt.Rows)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    OrderId = Convert.ToInt32(dr["OrderId"]),
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    UnitPrice = Convert.ToDecimal(dr["UnitPrice"]),
                    Quantity = Convert.ToInt32(dr["Quantity"]),
                    Discount = Convert.ToDecimal(dr["Discount"])
                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }
    }
}
