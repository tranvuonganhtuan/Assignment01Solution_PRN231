using BusinessObject;
using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class MemberAPI : ControllerBase
{
    private readonly IMemberRepository memberRepository;

    public MemberAPI(IMemberRepository memberRepository)
    {
        this.memberRepository = memberRepository;
    }

    // GET: api/MemberAPI
    [HttpGet]
    public IEnumerable<Member> Get()
    {
        return memberRepository.GetAllMembers();
    }

    // GET: api/MemberAPI/5
    [HttpGet("{id}", Name = "GetMember")]
    public Member Get(int id)
    {
        return memberRepository.GetMemberById(id);
    }

    // POST: api/MemberAPI
    [HttpPost]
    public void Post([FromBody] Member member)
    {
        memberRepository.AddMember(member);
    }

    // PUT: api/MemberAPI/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Member member)
    {
        // Ensure the provided member has the correct ID
        if (id != member.MemberId)
            return;

        memberRepository.UpdateMember(member);
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        memberRepository.DeleteMember(id);
    }
}
