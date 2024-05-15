using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangmentDAL.models
{
    public class Student : ModelBase
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public ICollection<Subject> subjects { get; set; } = new HashSet<Subject>();
        public ICollection<StudentSubject> studentSubjects { get; set; } = new HashSet<StudentSubject>();
    }
}