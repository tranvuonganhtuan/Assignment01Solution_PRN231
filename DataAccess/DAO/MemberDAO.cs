using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class MemberDAO
    {
        private readonly IMemberRepository _memberRepository;

        public MemberDAO(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        // Implement specific business logic or additional methods related to Member data access if needed
        // You can use _memberRepository to interact with the data store for members
    }
}
