using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssigmentCode.Models
{
	public class TraineeCourse
	{
		public int TraineeId { get; set; }
		public int CourseId { get; set; }
		public DateTime TimeStart { get; set; }
		public DateTime TimeEnd { get; set; }
		public Trainee Trainee { get; set; }
		public Course Course { get; set; }
	}
}
