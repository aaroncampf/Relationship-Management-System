using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship_Management_System.Database {
	public class PersonalDetail {
		public int Id { get; set; }
		//[MaxLength(4000)]
		public string Category { get; set; }
		//[MaxLength(4000)]
		public string Group { get; set; }
		//[MaxLength(4000)]
		public string Title { get; set; }
		//[MaxLength(4000)]
		public string Details { get; set; }
	}
}
