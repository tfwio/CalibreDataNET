/* oio * 7/25/2014 * Time: 7:23 PM */
using System;
using System.IO;
namespace CalibreData
{
	public class LibNode
	{
		public string Name
		{
			get { return Library.Name; }
		}
		
		public string LibraryPath {
			get { return Library.FullName; }
			set { Library = new DirectoryInfo(value); }
		}
		public string ImagePath {
			get { return Images.FullName; }
			set { Images = new DirectoryInfo(value); }
		}

		public DirectoryInfo Library {
			get;
			set;
		}

		public DirectoryInfo Images {
			get;
			set;
		}


		public void Update()
		{
			this.Library = Directory.Exists(LibraryPath) ? new DirectoryInfo(LibraryPath) : null;
			this.Images = Directory.Exists(ImagePath) ? new DirectoryInfo(ImagePath) : null;
		}
	}
}







