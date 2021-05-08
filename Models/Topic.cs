using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssigmentCode.Models
{
	public class Topic
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public Course Course { get; set; }
		public ICollection<TrainnerTopic> TrainnerTopics { get; set; }
	}
}
