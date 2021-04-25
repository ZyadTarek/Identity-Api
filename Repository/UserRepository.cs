using IdentityApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentityApi.Repository
{
	public class UserRepository : IRepository<User>
	{
		private IdentityContext _context;

		public UserRepository(IdentityContext context)
		{
			_context = context;
		}
		public User Add(User t)
		{
			if(t != null)
			{
				_context.Users.Add(t);
				_context.SaveChanges();
			}
			return t;
		}
		public bool Delete(int? id)
		{
           if(id != null)
			{
				_context.Users.Remove(_context.Users.FirstOrDefault(u=>u.Id == id));
				_context.SaveChanges();
				return true;
			}
			return false;
		}

		public User Edit(User t)
		{
			var user = GetById(t.Id);
			if(user != null)
			{
				_context.Update(user);
				_context.SaveChanges();
				return user;
			}
			return null;
		}

		public IQueryable<User> GetAll()
		{
			return _context.Users;
		}

		public User GetById(int? id)
		{
			if(id != null)
			{
				return _context.Users.FirstOrDefault(u => u.Id == id);
			}
			return null;
		}
		public List<User> GetAllAdmins()
		{
			return _context.UserRoles.Where(a => a.RoleId == 2).Select(a => a.User).ToList();
		}
		public bool CanLogin(User user)
		{
			var u = new User();
			if(user != null)
			{
			 u = GetAll().FirstOrDefault(c => c.Email == user.Email && c.Password == user.Password);
			 if (u != null) return true;
			}
			return false;
		}
	}
}
