using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void AddMember(Member member) => MemberDAO.AddMember(member);


        public void DeleteMember(Member member) => MemberDAO.DeleteMember(member);


        public List<Member> GetAllMembers() => MemberDAO.GetMembers();

        public Member GetMemberById(int id) => MemberDAO.FindMemberById(id);

        public void UpdateMember(Member member) => MemberDAO.UpdateMember(member);


    }
}
