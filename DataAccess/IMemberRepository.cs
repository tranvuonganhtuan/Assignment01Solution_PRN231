using BusinessObject;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        public Member GetMember(string email,string password);
    }
}
