using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship_Management_System.Database {
	public class Location {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Details { get; set; }
		public ActivityType Type { get; set; }

	}

	[Flags]
	public enum ActivityType {
		Dating_Casual = 1,
		Dating_Serious = 2,
		Recreational_Individual = 4,
		Recreational_Group = 4,
	}
}
