using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentMangmentDAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangmentBLL.Interfaces
{
	public interface IGenericRepository<T>  where T : ModelBase  
	{
		IEnumerable<T> GetAllStudent();

		void Add(T Entity);

		void Update(T Entity);

		void Delete(T Entity);
	}
}
