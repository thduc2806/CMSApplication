using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssigmentCode.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Time { get; set; }

		public ICollection<Course> Courses { get; set; }
	}
}
