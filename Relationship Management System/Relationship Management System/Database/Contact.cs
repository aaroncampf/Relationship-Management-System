using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship_Management_System.Database {
	public class Contact {
		public int Id { get; set; }
		//[MaxLength(4000)]
		public string Name { get; set; }
		//[MaxLength(4000)]
		public string Address { get; set; }
		//[MaxLength(4000)]
		public string City { get; set; }
		//[MaxLength(4000)]
		public string State { get; set; }
		//[MaxLength(4000)]
		public string Zip { get; set; }
		//[MaxLength(4000)]
		public string Profile { get; set; }
		public bool IsHidden { get; set; }
		public RelationshipState Status { get; set; }
		public HashSet<PersonalDetail> PersonalDetails { get; set; }
		public HashSet<ProCon> ProCons { get; set; }

		public Contact() {
			PersonalDetails = new HashSet<PersonalDetail>();
			ProCons = new HashSet<ProCon>();
		}
	}
}
