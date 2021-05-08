using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssigmentCode.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Time { get; set; }
		public int Slot { get; set; }
		public Category Category { get; set; }
		public ICollection<Topic> Topics { get; set; }
		public ICollection<TraineeCourse> TraineeCourses { get; set; }
	}
}
