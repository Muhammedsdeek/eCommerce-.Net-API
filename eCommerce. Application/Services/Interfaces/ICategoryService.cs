using eCommerce._Application.DTOs;
using eCommerce._Application.DTOs.Category;

namespace eCommerce._Application.Services.Interfaces
{
	public interface ICategoryService
	{

		Task<IEnumerable<GetCategory>> GetAllAsync();

		Task<GetCategory> GetByIdAsync(Guid id);

		Task<ServiceResponse> AddAsync(CreateCategory entity);

		Task<ServiceResponse> UpdateAsync(UpdateCategory entity);

		Task<ServiceResponse> DeleteAsync(Guid id);

	}
}
