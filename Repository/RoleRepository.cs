using IdentityApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityApi.Repository
{
	public class RoleRepository:IRepository<Role>
	{
		private IdentityContext _context;

		public RoleRepository(IdentityContext context)
		{
			_context = context;
		}
		public Role Add(Role t)
		{
			if (t != null)
			{
				_context.Roles.Add(t);
				_context.SaveChanges();
			}
			return t;
		}
		public bool Delete(int? id)
		{
			if (id != null)
			{
				_context.Roles.Remove(_context.Roles.FirstOrDefault(u => u.Id == id));
				_context.SaveChanges();
				return true;
			}
			return false;
		}

		public Role Edit(Role t)
		{
			var role = GetById(t.Id);
			if (role != null)
			{
				_context.Update(role);
				_context.SaveChanges();
				return role;
			}
			return null;
		}

		public IQueryable<Role> GetAll()
		{
			return _context.Roles;
		}

		public Role GetById(int? id)
		{
			if (id != null)
			{
				return _context.Roles.FirstOrDefault(u => u.Id == id);
			}
			return null;
		}
	}
}
