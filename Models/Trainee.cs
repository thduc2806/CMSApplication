using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssigmentCode.Models
{
	public class Trainee : Person
	{
		public string ProgrammingLanguage { get; set; }
		public float TOEIC { get; set; }

		public ICollection<TraineeCourse> TraineeCourses { get; set; }
	}
}
