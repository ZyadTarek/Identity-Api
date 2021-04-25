using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityApi.Repository
{
	public interface IRepository<T>
	{
		T Add(T t);
		IQueryable<T> GetAll();
		bool Delete(int? id);
		T GetById(int? id);
		T Edit(T t);
	}
}
