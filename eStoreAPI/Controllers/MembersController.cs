using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccess.Repository;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private IMemberRepository repository = new MemberRepository();
        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetMembers() => repository.GetAllMembers();
        [HttpPost]
        public IActionResult PostMembers(Member m)
        {
            repository.AddMember(m);
            return NoContent();
        }
        [HttpDelete("id")]
        public IActionResult DeleteMember(int id)
        {
            var p = repository.GetMemberById(id);
            if (p == null)
            {
                return NotFound();
            }
            repository.DeleteMember(p);
            return NoContent();
        }
        [HttpPut("id")]
        public IActionResult UpdateMember(int id, Member m)
        {
            var mTmp = repository.GetMemberById(id);
            if (m == null)
            {
                return NotFound();
            }
            repository.UpdateMember(m);
            return NoContent();
        }
    }
}
