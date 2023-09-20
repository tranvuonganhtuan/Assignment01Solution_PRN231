using BusinessObject;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO : IMemberRepository
    {
        private List<Member> members = new List<Member>();  // Simulated data store

        public Member GetMemberById(int memberId)
        {
            return members.FirstOrDefault(m => m.MemberId == memberId);
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return members;
        }

        public void AddMember(Member member)
        {
            members.Add(member);
        }

        public void UpdateMember(Member member)
        {
            // Update the member in the data store
            var existingMember = members.FirstOrDefault(m => m.MemberId == member.MemberId);
            if (existingMember != null)
            {
                existingMember.Email = member.Email;
                existingMember.CompanyName = member.CompanyName;
                existingMember.City = member.City;
                existingMember.Country = member.Country;
                existingMember.Password = member.Password;
            }
        }

        public void DeleteMember(int memberId)
        {
            // Delete the member from the data store
            var memberToRemove = members.FirstOrDefault(m => m.MemberId == memberId);
            if (memberToRemove != null)
            {
                members.Remove(memberToRemove);
            }
        }
    }
}
