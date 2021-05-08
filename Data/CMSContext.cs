using AssigmentCode.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssigmentCode.Data
{
	public class CMSContext : DbContext
	{
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Training> Trainings { get; set; }
		public DbSet<Trainner> Trainners { get; set; }
		public DbSet<Trainee> Trainees { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Topic> Topics { get; set; }
		public DbSet<TrainnerTopic> TrainnerTopics { get; set; }
		public DbSet<TraineeCourse> TraineeCourses { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-2URRFJ3;Initial Catalog=CMSWebApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TrainnerTopic>().HasKey(tt => new { tt.TrainnerId, tt.TopicId });

			modelBuilder.Entity<TrainnerTopic>()
				.HasOne<Trainner>(tt => tt.Trainner)
				.WithMany(s => s.TrainnerTopics)
				.HasForeignKey(tt => tt.TrainnerId);

			modelBuilder.Entity<TrainnerTopic>()
				.HasOne<Topic>(tt => tt.Topic)
				.WithMany(s => s.TrainnerTopics)
				.HasForeignKey(tt => tt.TopicId);

			modelBuilder.Entity<TraineeCourse>().HasKey(tc => new { tc.TraineeId, tc.CourseId });

			modelBuilder.Entity<TraineeCourse>()
				.HasOne<Trainee>(tc => tc.Trainee)
				.WithMany(s => s.TraineeCourses)
				.HasForeignKey(tc => tc.TraineeId);

			modelBuilder.Entity<TraineeCourse>()
				.HasOne<Course>(tc => tc.Course)
				.WithMany(s => s.TraineeCourses)
				.HasForeignKey(tc => tc.CourseId);
		}
	}
}
