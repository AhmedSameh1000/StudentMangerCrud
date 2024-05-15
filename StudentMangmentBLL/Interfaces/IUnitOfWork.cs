using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangmentBLL.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		public IStudetRepository studetRepository { get; set; }
		
		public ISubjectRepository subjectRepository { get; set; }

		int Complete();
	}
}
