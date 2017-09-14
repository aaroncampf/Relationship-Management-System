using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship_Management_System.Classes {
	class StringVisitor_Class : IStringVisitor {
		public string Data { get; private set; }
		public void Visit(string str) {
			if (!string.IsNullOrEmpty(str)) {
				Data = str;				
			}
		}

		public void Dispose() {
			//throw new NotImplementedException();
		}
	}
}
