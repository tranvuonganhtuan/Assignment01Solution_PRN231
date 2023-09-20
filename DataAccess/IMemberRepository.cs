using BusinessObject;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IMemberRepository
    {
        Member GetMemberById(int memberId);
        IEnumerable<Member> GetAllMembers();
        void AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int memberId);
    }
}
