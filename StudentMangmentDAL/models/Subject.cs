using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangmentDAL.models
{
    public class Subject : ModelBase
    {
        public string Name { get; set; }

        public ICollection<Student> students { get; set; } = new HashSet<Student>();

        public ICollection<StudentSubject> studentSubjects { get; set; } = new HashSet<StudentSubject>();
    }
}