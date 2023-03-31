using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

#nullable disable

namespace eStore.Models
{
    public partial class Member
    {
        public Member()
        {
            Orders = new HashSet<Order>();
        }

        public int MemberId { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public static void DeleteMember(int memberId)
        {
            try
            {
                string sql = "DELETE od FROM OrderDetail od INNER JOIN [Order] o ON od.OrderId = o.OrderId WHERE o.MemberId = @MemberId delete from [Order] where MemberId=@MemberId DELETE FROM Member WHERE MemberId=@MemberId";
                SqlParameter parameter = new SqlParameter("@MemberId", SqlDbType.Int);
                parameter.Value = memberId;
                DbContext.UpdateDataBySql(sql, parameter);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                // For example:
                Console.WriteLine("An error occurred while deleting the member: " + ex.Message);
                throw; // re-throw the exception to propagate it up the call stack
            }
        }
    }
}
