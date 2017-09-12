using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship_Management_System.Database {
  public class Setting {

    public int Id { get; set; }

    /// <summary>
    /// All matches much exceed this core to not be rejected.
    /// </summary>
    public int MinimalRequredScoreForMatch { get; set; }
  }
}
