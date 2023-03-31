using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        //using singleton pattern
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Member> GetAllMembers()
        {
            List<Member> members = null;
            try
            {
                using var context = new PRN_Ass2Context();
                members = context.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public Member GetMemberByEmail(string email)
        {
            Member member = null;
            try
            {
                using var context = new PRN_Ass2Context();
                member = context.Members.SingleOrDefault(m => m.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public void AddMember(Member member)
        {
            try
            {
                Member existingMember = GetMemberByEmail(member.Email);
                if (existingMember == null)
                {
                    using var context = new PRN_Ass2Context();
                    context.Members.Add(member);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateMember(Member member)
        {
            try
            {
                Member existingMember = GetMemberByEmail(member.Email);
                if (existingMember != null)
                {
                    using var context = new PRN_Ass2Context();
                    context.Members.Update(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveMemberByEmail(string email)
        {
            try
            {
                Member member = GetMemberByEmail(email);
                if (member != null)
                {
                    using var context = new PRN_Ass2Context();
                    context.Members.Remove(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal Member GetMemberByEmail(object memberId)
        {
            throw new NotImplementedException();
        }
    }
}
