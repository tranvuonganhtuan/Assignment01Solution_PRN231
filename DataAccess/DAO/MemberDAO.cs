using BusinessObject.Models;
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
        public static List<Member> GetMembers()
        {
            var listMembers = new List<Member>();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    listMembers = context.Members.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listMembers;
        }
        public static Member FindMemberById(int memId)
        {
            Member m = new Member();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    m = context.Members.SingleOrDefault(x => x.MemberId == memId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return m;
        }
        public static void AddMember(Member m)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Members.Add(m);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteMember(Member m)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    var p1 = context.Members.SingleOrDefault(x => x.MemberId == m.MemberId);
                    context.Members.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateMember(Member m)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Entry<Member>(m).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
