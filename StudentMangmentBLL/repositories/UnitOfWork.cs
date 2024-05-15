using StudentMangmentBLL.Interfaces;
using StudentMangmentDAL.DbContxet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangmentBLL.repositories
{
	public class UnitOfWork : IUnitOfWork 
	{
		private readonly StudentDbContect _studentDbContect;

	
        public IStudetRepository studetRepository { get ; set ; }
		public ISubjectRepository subjectRepository { get; set; }

		public UnitOfWork(StudentDbContect studentDbContect)
		{
			this._studentDbContect = studentDbContect;
			studetRepository = new StudentRepository(_studentDbContect);
			subjectRepository = new SubjectRepository(_studentDbContect);
		}
		public int Complete()
		{
			return _studentDbContect.SaveChanges();	
		}

		public void Dispose()
		{
			_studentDbContect?.Dispose();
		}
	}
}
