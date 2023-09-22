
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        Member GetMemberById(int memberId);
        List<Member> GetAllMembers();
        void AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(Member member);
    }
}
