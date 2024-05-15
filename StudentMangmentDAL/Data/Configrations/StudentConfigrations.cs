using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentMangmentDAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangmentDAL.Data.Configrations
{
    public class StudentConfigrations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(S => S.Name).IsRequired()
                    .HasMaxLength(100);

            builder.Property(S => S.Address).IsRequired()
                   .HasMaxLength(100);
            builder.HasMany(c => c.subjects).WithMany(c => c.students).UsingEntity<StudentSubject>();
        }
    }
}