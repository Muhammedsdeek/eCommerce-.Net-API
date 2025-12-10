using eCommerce._Application.DTOs;
using eCommerce._Application.DTOs.Product;
using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Services.Interfaces
{
	public interface IproductService
	{

		Task<IEnumerable<GetProduct>> GetAllAsync();

		Task<GetProduct> GetByIdAsync(Guid id);

		Task<ServiceResponse> AddAsync(CreateProduct entity);

		Task<ServiceResponse> UpdateAsync(UpdateProduct entity);

		Task<ServiceResponse> DeleteAsync(Guid id);
	}
}
