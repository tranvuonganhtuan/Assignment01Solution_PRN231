using AutoMapper;
using BusinessObject;
    using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DataAccess
    {
    public class MemberDAO : IGenericRepository<Member>
    {
        private readonly FStoreDBContext _context;
        private readonly IMapper _mapper;

        public MemberDAO(FStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Member> GetAll()
        {
            var members = _context.Members.ToList();
            return _mapper.Map<List<Member>>(members);
        }

        public Member GetById(object id)
        {
            var memberId = Convert.ToInt32(id);
            var memberEntity = _context.Members.FirstOrDefault(m => m.MemberId == memberId);
            return _mapper.Map<Member>(memberEntity);
        }

        public void Insert(Member member)
        {
            var memberEntity = _mapper.Map<Member>(member);
            _context.Members.Add(memberEntity);
            _context.SaveChanges();
        }

        public void Update(Member member)
        {
            var memberEntity = _mapper.Map<Member>(member);
            _context.Entry(memberEntity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            var memberId = Convert.ToInt32(id);
            var existing = _context.Members.FirstOrDefault(m => m.MemberId == memberId);
            if (existing != null)
            {
                _context.Members.Remove(existing);
                _context.SaveChanges();
            }
        }

       
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
