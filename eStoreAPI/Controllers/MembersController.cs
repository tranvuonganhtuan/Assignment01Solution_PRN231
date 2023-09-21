using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.Models;
using DataAccess;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IGenericRepository<Member> _memberRepository;

        public MembersController(IGenericRepository<Member> memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            var members = _memberRepository.GetAll();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = _memberRepository.GetById(id);
            if (member == null)
                return NotFound();

            return member;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member member)
        {
            if (id != member.MemberId)
                return BadRequest();

            _memberRepository.Update(member);
            _memberRepository.Save();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            _memberRepository.Insert(member);
            _memberRepository.Save();

            return CreatedAtAction("GetMember", new { id = member.MemberId }, member);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            _memberRepository.Delete(id);
            _memberRepository.Save();

            return NoContent();
        }
    }
}
