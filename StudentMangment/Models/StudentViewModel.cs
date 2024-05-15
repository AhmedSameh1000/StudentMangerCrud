using StudentMangmentDAL.models;
using System.ComponentModel.DataAnnotations;

namespace StudentMangment.Models
{
    public class StudentViewModel
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }

        public List<SubjectViewModel> subjects { get; set; } = new List<SubjectViewModel>();
    }

    public class SubjectViewModel
    {
        public int id { get; set; }

        public string Name { get; set; }

        public bool IsSlected { get; set; }
    }
}