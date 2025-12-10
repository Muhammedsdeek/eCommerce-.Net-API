using eCommerce._Application.DTOs;
using eCommerce._Application.DTOs.Product;
using eCommerce._Application.Services.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Services.Implementations
{
	internal class ProductService(Igeneric<Product> ProductInterface) : IproductService
	{
		public async Task<ServiceResponse> AddAsync(CreateProduct entity)
		{

			//return await ProductInterface.AddAsync();
			throw new NotImplementedException();

		}

		public Task<ServiceResponse> DeleteAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<GetProduct>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<GetProduct> GetByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse> UpdateAsync(UpdateProduct entity)
		{
			throw new NotImplementedException();
		}
	}
}
