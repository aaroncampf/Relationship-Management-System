using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> origin/master
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship_Management_System.Database {
	public class ContactedProfiles {
		public int Id { get; set; }
		//[MaxLength(4000)]
		public string URL { get; set; }
		public DateTime LastContacted { get; set; }
	}
}
