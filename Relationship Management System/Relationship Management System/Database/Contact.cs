using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship_Management_System.Database {
  public class Contact {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Profile { get; set; }
    public RelationshipState Status { get; set; }
    public HashSet<PersonalDetail> PersonalDetails { get; set; }
    public HashSet<ProCon> ProCons { get; set; }


    //TODO: Add ProCon

    public Contact() {
      PersonalDetails = new HashSet<PersonalDetail>();
      ProCons = new HashSet<ProCon>();
    }
  }
}
