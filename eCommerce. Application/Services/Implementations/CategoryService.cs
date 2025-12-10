using eCommerce._Application.DTOs;
using eCommerce._Application.DTOs.Category;
using eCommerce._Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Services.Implementations
{
	internal class CategoryService : ICategoryService
	{
		public Task<ServiceResponse> AddAsync(CreateCategory entity)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse> DeleteAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<GetCategory>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<GetCategory> GetByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse> UpdateAsync(UpdateCategory entity)
		{
			throw new NotImplementedException();
		}
	}
}
