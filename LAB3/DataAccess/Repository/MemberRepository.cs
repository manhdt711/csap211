using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void AddNew(Member member) => MemberDAO.Instance.AddMember(member);

        public Member GetMemberByEmail(string email) => MemberDAO.Instance.GetMemberByEmail(email);

        public IEnumerable<Member> GetMemberList() => MemberDAO.Instance.GetAllMembers();
        public void Remove(string email) => MemberDAO.Instance.RemoveMemberByEmail(email);

        public void Update(Member member) => MemberDAO.Instance.UpdateMember(member);
    }
}
