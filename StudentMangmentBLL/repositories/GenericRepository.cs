using Microsoft.EntityFrameworkCore;
using StudentMangmentBLL.Interfaces;
using StudentMangmentDAL.DbContxet;
using StudentMangmentDAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangmentBLL.repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
	{
		private readonly StudentDbContect _studentDbContect;

		public GenericRepository(StudentDbContect studentDbContect ) 
		{
			this._studentDbContect = studentDbContect;
		}
		public void Add(T Entity)
		{
			_studentDbContect.Set<T>().Add(Entity);
		}

		public void Delete(T Entity)
		{
			_studentDbContect.Set<T>().Remove(Entity);
		}

		

		public IEnumerable<T> GetAllStudent()  
		{
			if (typeof(T) == typeof(Student))
			{
				return (IEnumerable<T>) _studentDbContect.Set<Student>().Include(S => S.subjects).ToList();
			}
			if(typeof(T) == typeof(Subject))
			{
				return (IEnumerable<T>)_studentDbContect.Set<Subject>().ToList();

            }
			var Students = _studentDbContect.Set<T>().ToList(); 

			return Students;
		}

		public void Update(T Entity)
		{
			_studentDbContect.Set<T>().Update(Entity);
		}
	}
}
