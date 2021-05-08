using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssigmentCode.Models
{
	public class TrainnerTopic
	{
		public int TrainnerId { get; set; }
		public int TopicId { get; set; }
		public DateTime TimeStart { get; set; }
		public DateTime TimeEnd { get; set; }

		public Topic Topic { get; set; }
		public Trainner Trainner { get; set; }
	}
}
