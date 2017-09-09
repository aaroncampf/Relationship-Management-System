using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship_Management_System.Database {
	public class Interest {
		public int Id { get; set; }
		//[MaxLength(4000)]
		public string Name { get; set; }
		//[MaxLength(4000)]
		public string Message { get; set; }
	}
}
