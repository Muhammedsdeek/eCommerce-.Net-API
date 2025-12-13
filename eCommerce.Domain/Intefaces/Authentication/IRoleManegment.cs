using eCommerce.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Intefaces.Authentication
{
	public interface IRoleManegment
	{

		Task<string?> GetUserRole(string userId);

		Task<bool> AddUserToRole(AppUser User,string RoleName);


	}
}
