﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApi.Models
{
	public class User_Role
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("User")]
		public int UserId { get; set; }
		[ForeignKey("Role")]
		public int RoleId { get; set; }
		public Role Role { get; set; }
		public User User { get; set; }
	}
}
