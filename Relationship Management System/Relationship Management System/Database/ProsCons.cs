using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship_Management_System.Database {
	/// <summary>
	/// Think of a better name
	/// </summary>
	public class ProCon {
		public int Id { get; set; }
		public int Points { get; set; }
		public string Title { get; set; }

		public Contact Contact { get; set; }
	}
}
