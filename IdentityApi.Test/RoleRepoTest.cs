using System;
using Xunit;
using IdentityApi.Repository;
using IdentityApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Test
{
	public class RoleRepoTest
	{
		private RoleRepository roleRepository;
		private UserRepository userRepository;
		public RoleRepoTest()
		{
			
			roleRepository = new RoleRepository(new IdentityContext());
			userRepository = new UserRepository(new IdentityContext());
		}
		[Fact]
		public void IsAdminRoleAvailableTrueTest()
		{
			var admins = new List<User>();
			foreach(var role in roleRepository.GetAll())
			{
				if(role.Name.Equals("Admin", StringComparison.OrdinalIgnoreCase))
				{
				Assert.True(role.Name.Equals("Admin", StringComparison.OrdinalIgnoreCase));
				break;
				}
			}
			Assert.True(userRepository.GetAllAdmins().Count >= 1);
		}
		[Fact]
		public void IsAdminUserAvailableFalseTest()
		{
			Assert.False(userRepository.GetAllAdmins().Count < 1);
		}
		[Fact]
		public void CanLoginTrueTest()
		{
			Assert.True(userRepository.CanLogin(new User {Id = 2,Username="Zyad",Email="zyad.tarek175@gmail.com",Password="456"}));
		}
		[Fact]
		public void CanLoginFalseTest()
		{
			Assert.False((userRepository.CanLogin(new User { Id = 2, Username = "Zyad", Email = "zyad.tarek175@gmail.com", Password = "4566" })));
		}
	}
}
