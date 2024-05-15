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
	public class StudentRepository : GenericRepository<Student> ,IStudetRepository
	{
		public StudentRepository(StudentDbContect studentDbContect) : base(studentDbContect)
		{

		}
	}
}
