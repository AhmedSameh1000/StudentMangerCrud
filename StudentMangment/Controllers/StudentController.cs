using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NuGet.Packaging;
using StudentMangment.Models;
using StudentMangmentBLL.Interfaces;
using StudentMangmentDAL.DbContxet;
using StudentMangmentDAL.models;

namespace StudentMangment.Controllers
{
    public class StudentController : Controller
    {
        private readonly IGenericRepository<Student> _studentRepo;
        private readonly StudentDbContect studentDbContect;

        public StudentController(
            IGenericRepository<Student> studentRepo,
            StudentDbContect studentDbContect
            )
        {
            this._studentRepo = studentRepo;
            this.studentDbContect = studentDbContect;
        }

        public IActionResult Index()
        {
            var Student = _studentRepo.GetAllStudent();

            return View(Student);
        }

        public IActionResult Create(int id)
        {
            var sd = new StudentViewModel();
            if (id == 0)
            {
                var StudentViewModel = new StudentViewModel()
                {
                    subjects = studentDbContect.subjects.Select(S => new SubjectViewModel { id = S.Id, Name = S.Name }).ToList()
                };

                //sd.subjects = studentDbContect.subjects.Select(S => new SubjectViewModel { id = S.Id, Name = S.Name }).ToList();
                return View(StudentViewModel);
            }
            else
            {
                var Student = _studentRepo.GetAllStudent().FirstOrDefault(S => S.Id == id);

                var StudentViewModel = new StudentViewModel()
                {
                    Id = id,
                    Name = Student.Name,
                    DateOfBirth = Student.DateOfBirth,
                    Address = Student.Address,
                    subjects = studentDbContect.subjects
                .Select(S => new SubjectViewModel
                {
                    id = S.Id,
                    Name = S.Name,
                    IsSlected = Student.subjects.Select(A => A.Id).ToList().Contains(S.Id)
                })
                .ToList()
                };
                return View(StudentViewModel);
            }
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel studentvm, int id)
        {
            if (id == 0)
            {
                var studnt = new Student()
                {
                    Address = studentvm.Address,
                    Name = studentvm.Name,
                    DateOfBirth = studentvm.DateOfBirth,
                    studentSubjects = studentvm.subjects.Where(c => c.IsSlected).Select(A => new StudentSubject()
                    {
                        SubjectId = A.id,
                    }).ToList()
                };

                studentDbContect.students.Add(studnt);

                studentDbContect.SaveChanges();
            }
            else
            {
                var Studnet = studentDbContect.students.Include(c => c.studentSubjects).FirstOrDefault(c => c.Id == id);
                Studnet.Name = studentvm.Name;
                Studnet.Address = studentvm.Address;
                Studnet.DateOfBirth = studentvm.DateOfBirth;

                studentDbContect.studentSubjects.RemoveRange(Studnet.studentSubjects);

                foreach (var Subject in studentvm.subjects.Where(c => c.IsSlected))
                {
                    Studnet.studentSubjects.Add(new StudentSubject()
                    {
                        SubjectId = Subject.id,
                    });
                }

                studentDbContect.Update(Studnet);
                studentDbContect.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var student = studentDbContect.students.FirstOrDefault(c => c.Id == id);

            if (student is null)
                return NotFound();

            studentDbContect.students.Remove(student);

            return Ok(studentDbContect.SaveChanges());
        }
    }
}