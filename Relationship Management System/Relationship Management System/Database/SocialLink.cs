using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship_Management_System.Database {
	/// <summary>
	/// Represents a person in your social network that could link you to potential contacts
	/// </summary>
	public class SocialLink {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Profile { get; set; }
		public string Details { get; set; }
	}
}
