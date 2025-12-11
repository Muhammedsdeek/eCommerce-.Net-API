
using eCommerce.Domain.Intefaces;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositries
{
	public class GenericRepositry<TEntity>(AppDbContext Context) : Igeneric<TEntity> where TEntity : class
	{

		
		public async Task<int> AddAsync(TEntity entity)
		{
			

			  Context.Set<TEntity>().Add(entity);
			return await Context.SaveChangesAsync();
		}

		public async Task<int> DeleteAsync(Guid id)
		{

			var result = await GetByIdAsync(id);
			//?? throw new ItemNotFounException($"Item With Id : ({id}) Bot Found Found");

			if(result is null)
				return 0;
			Context.Set<TEntity>().Remove(result);
			return await Context?.SaveChangesAsync();	
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{

			return await Context.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity> GetByIdAsync(Guid id)
		{
			var Result = await Context.Set<TEntity>().FindAsync(id);
			return Result;

		}

		public async Task<int> UpdateAsync(TEntity entity)
		{
			Context.Set<TEntity>().Update(entity);
			return await Context.SaveChangesAsync();
		}
	}
}
