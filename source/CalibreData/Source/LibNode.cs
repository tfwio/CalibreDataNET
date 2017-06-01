/* oio * 7/25/2014 * Time: 7:23 PM */
using System;
using System.IO;
namespace CalibreData
{
	/// <summary>
	/// This is one of the few strategies that remains.
	/// It is a generally obsolete concept, though the work-around,
	/// though the regeneration process in LibraryCollection works.
	/// <para>
	/// This class should ONLY be used for the CopyCalibreCovers utility
	/// application, though it is currently stored in the LibraryCollection.
	/// </para>
	/// </summary>
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
		/// <summary>
		/// This method is not used AT ALL.
		/// </summary>
		public void Update()
		{
			this.Library = Directory.Exists(LibraryPath) ? new DirectoryInfo(LibraryPath) : null;
			this.Images = Directory.Exists(ImagePath) ? new DirectoryInfo(ImagePath) : null;
		}
	}
}







