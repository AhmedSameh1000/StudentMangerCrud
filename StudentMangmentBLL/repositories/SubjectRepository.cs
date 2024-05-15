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
	public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
	{
		public SubjectRepository(StudentDbContect studentDbContect) : base(studentDbContect)
		{
		}
	}
}
