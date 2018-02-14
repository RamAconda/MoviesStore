using System;
using System.Collections.Generic;
using System.Linq;

namespace Vidly.Models
{
    public class MembershipTypesManager
    {
        private readonly ApplicationDbContext _context;

        public MembershipTypesManager(ApplicationDbContext context)
        {
            if (context == null)
            {
                throw new Exception("_context can't be assigned to null, it needs to be instantiated.");
            }
            _context = context;
        }

        private void ThrowContextExceptionIfNull()
        {
            if (_context == null)
            {
                throw new Exception("_context is null, can't be used.");
            }
        }

        public IQueryable<MembershipType> GetMembershipTypes()
        {
            ThrowContextExceptionIfNull();
            return _context.MembershipTypes;
        }

        public List<MembershipType> GetMembershipTypesAsList()
        {
            return GetMembershipTypes().ToList();
        }

        public MembershipType GetMembershipTypeById(int id)
        {
            return GetMembershipTypes().SingleOrDefault(membershipType => membershipType.Id == id);
        }
    }
}