using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Intefaces
{
	public interface Igeneric<Tentity> where Tentity : class
	{

		Task<IEnumerable<Tentity>> GetAllAsync();

		Task<Tentity> GetByIdAsync(Guid id);

		Task<int>	 AddAsync(Tentity entity);

		Task<int> UpdateAsync(Tentity entity);

		Task<int> DeleteAsync(Guid id);

	}
}
