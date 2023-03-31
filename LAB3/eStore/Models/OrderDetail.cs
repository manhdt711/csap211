using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

#nullable disable

namespace eStore.Models
{
    public partial class OrderDetail
    {
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public double? Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
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
                    Discount = (double?)Convert.ToDecimal(dr["Discount"])
                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }
    }
}
