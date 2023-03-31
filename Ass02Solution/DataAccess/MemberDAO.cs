using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess
{
    public class MemberDAO
    {
        public static Member GetMemberById(int memberId)
        {
            string sql = "SELECT * FROM Member WHERE MemberID = @MemberID";
            SqlParameter parameter = new SqlParameter("@MemberID", DbType.Int32);
            parameter.Value = memberId;
            DataTable dt = DbContext.GetDataBySql(sql, parameter);
            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];
            return new Member
            {
                MemberID = Convert.ToInt32(dr["MemberID"]),
                Email = dr["Email"].ToString(),
                CompanyName = dr["CompanyName"].ToString(),
                City = dr["City"].ToString(),
                Country = dr["Country"].ToString(),
                Password = dr["Password"].ToString()
            };
        }

        public static List<Member> GetAllMembers()
        {
            string sql = "SELECT * FROM Member";
            DataTable dt = DbContext.GetDataBySql(sql);

            List<Member> members = new List<Member>();
            foreach (DataRow dr in dt.Rows)
            {
                members.Add(new Member
                {
                    MemberID = Convert.ToInt32(dr["MemberID"]),
                    Email = dr["Email"].ToString(),
                    CompanyName = dr["CompanyName"].ToString(),
                    City = dr["City"].ToString(),
                    Country = dr["Country"].ToString(),
                    Password = dr["Password"].ToString()
                });
            }
            return members;
        }

        public static void AddMember(Member member)
        {
            try
            {
                // Insert new member
                string sql = "INSERT INTO [Member] (Email, CompanyName, City, Country, [Password]) VALUES (@Email, @CompanyName, @City, @Country, @Password)";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Email", SqlDbType.VarChar) { Value = member.Email },
            new SqlParameter("@CompanyName", SqlDbType.VarChar) { Value = member.CompanyName },
            new SqlParameter("@City", SqlDbType.VarChar) { Value = member.City },
            new SqlParameter("@Country", SqlDbType.VarChar) { Value = member.Country },
            new SqlParameter("@Password", SqlDbType.VarChar) { Value = member.Password }
                };
                DbContext.UpdateDataBySql(sql, parameters);
            }
            catch (Exception ex)
            {
                // Handle the exception here, e.g. log the error and/or show an error message to the user
                Console.WriteLine("Error adding member: " + ex.Message);
            }
        }

        public static void UpdateMember(Member member)
        {
            try
            {
                string sql = "UPDATE Member SET Email=@Email, CompanyName=@CompanyName, City=@City, Country=@Country, Password=@Password WHERE MemberId=@MemberId";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Email", SqlDbType.VarChar) { Value = member.Email },
            new SqlParameter("@CompanyName", SqlDbType.VarChar) { Value = member.CompanyName },
            new SqlParameter("@City", SqlDbType.VarChar) { Value = member.City },
            new SqlParameter("@Country", SqlDbType.VarChar) { Value = member.Country },
            new SqlParameter("@Password", SqlDbType.VarChar) { Value = member.Password },
            new SqlParameter("@MemberId", SqlDbType.Int) { Value = member.MemberID }
                };
                DbContext.UpdateDataBySql(sql, parameters);
            }
            catch (Exception ex)
            {
                // log the error and throw a custom exception
                string errorMessage = $"An error occurred while updating the member with ID {member.MemberID}: {ex.Message}";
                throw new Exception(errorMessage);
            }
        }


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

        public static Member CheckLogin(String email, String password)
        {
            string sql = "select * from Member where Email = @email AND [Password]=@password ";
            SqlParameter parameter1 = new SqlParameter("@email", email);
            SqlParameter parameter2 = new SqlParameter("@password", password);
            DataTable dt = DbContext.GetDataBySql(sql, parameter1, parameter2);
            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];
            return new Member
            {
                MemberID = Convert.ToInt32(dr["MemberId"]),
                Email = dr["Email"].ToString(),
                CompanyName = dr["CompanyName"].ToString(),
                City = dr["City"].ToString(),
                Country = dr["Country"].ToString(),
                Password = dr["Password"].ToString()
            };
        }


    }
}
