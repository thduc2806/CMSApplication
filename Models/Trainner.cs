using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssigmentCode.Models
{
	public class Trainner : Person
	{
		public string Phone { get; set; }
		public string Education { get; set; }
		public string WorkingPlace { get; set; }

		public ICollection<TrainnerTopic> TrainnerTopics { get; set; }
	}
}
