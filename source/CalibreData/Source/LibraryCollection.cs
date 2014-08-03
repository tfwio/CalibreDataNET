/* oio * 7/25/2014 * Time: 7:23 PM */
using System;
using System.Collections.Generic;
using System.IO;
namespace CalibreData
{
	public class LibraryCollection : List<LibNode>
	{
		DirectoryInfo BaseLibrary {
			get;
			set;
		}

		DirectoryInfo BaseImages {
			get;
			set;
		}

		public void Add(params string[] pathNames)
		{
			if (pathNames != null) foreach (var p in pathNames) Add(p);
		}

		public LibraryCollection(string baseLib, string baseImg, params string[] pathNames)
		{
			BaseLibrary = new DirectoryInfo(baseLib);
			BaseImages = new DirectoryInfo(baseImg);
			Add(pathNames);
			this.Sort((a, b) => string.Compare(a.ImagePath, b.ImagePath, StringComparison.Ordinal));
		}

		public void Add(string libraryName)
		{
			this.Add(
				new LibNode() {
					Library = new DirectoryInfo(Path.Combine(BaseLibrary.FullName, libraryName)),
					Images = new DirectoryInfo(Path.Combine(BaseImages.FullName, libraryName))
				});
		}
	}
}







