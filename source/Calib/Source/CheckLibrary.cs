/* oio * 7/25/2014 * Time: 7:23 PM */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace CalibreData.Models
{
	/// <summary>
	/// Usage: Set Model, Execute the command.
	/// LibraryCollection is the result.
	/// Q: What are we checking?
	/// A: Compare the result to the library in memory?
	/// Q: Why did the answer have a question-mark?
	/// A: You tell me.
	/// </summary>
	public class CheckLibrary
	{
		public LibraryCollection Lib {
			get;
			set;
		}

		public InfoModel Model {
			get;
			set;
		}

		public void Command()
		{
			Lib = new LibraryCollection(Model.libroot, Model.imgroot, null, Model.dirs) {

			};
		}
	}
}









