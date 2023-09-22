using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly FStoreDBContext _dbContext;

        public MemberRepository(FStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Member GetMemberById(int memberId)
        {
            return _dbContext.Members.FirstOrDefault(m => m.MemberId == memberId);
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _dbContext.Members.ToList();
        }

        public void AddMember(Member member)
        {
            _dbContext.Members.Add(member);
            _dbContext.SaveChanges();
        }

        public void UpdateMember(Member member)
        {
            _dbContext.Members.Update(member);
            _dbContext.SaveChanges();
        }

        public void DeleteMember(int memberId)
        {
            var member = _dbContext.Members.FirstOrDefault(m => m.MemberId == memberId);
            if (member != null)
            {
                _dbContext.Members.Remove(member);
                _dbContext.SaveChanges();
            }
        }

        
    }
}
