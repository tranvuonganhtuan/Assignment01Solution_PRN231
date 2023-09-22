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
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        // GET: api/Members
        [HttpGet]
        public IEnumerable<Member> GetAllMembers()
        {
            return _memberRepository.GetAllMembers();
        }

        [HttpGet("{id}")]
        public ActionResult<Member> GetMemberById(int id)
        {
            var member = _memberRepository.GetMemberById(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        [HttpPost]
        public ActionResult<Member> AddMember([FromBody] Member member)
        {
            _memberRepository.AddMember(member);
            return CreatedAtAction(nameof(GetMemberById), new { id = member.MemberId }, member);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, [FromBody] Member member)
        {
            if (id != member.MemberId)
            {
                return BadRequest();
            }

            _memberRepository.UpdateMember(member);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            var member = _memberRepository.GetMemberById(id);

            if (member == null)
            {
                return NotFound();
            }

            _memberRepository.DeleteMember(id);
            return NoContent();
        }
    }
}
