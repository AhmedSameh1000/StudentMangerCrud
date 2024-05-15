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
	public class SubjectConfigrations : IEntityTypeConfiguration<Subject>
	{
		public void Configure(EntityTypeBuilder<Subject> builder)
		{
			builder.Property(b=>b.Name).IsRequired()
			                           .HasMaxLength(50);
		}
	}
}
