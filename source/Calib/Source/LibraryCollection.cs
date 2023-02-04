/* oio * 7/25/2014 * Time: 7:23 PM */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CalibreData.Models
{
	public class LibraryCollectionOptions
	{
		static public readonly LibraryCollectionOptions Default = new LibraryCollectionOptions(){
			AutoIgnore=true
		};
		/// <summary>
		/// Add ignored libraries to the list of ignored libraries.
		/// Useful when reading conf.json.
		/// </summary>
		public bool AutoIgnore { get;set; }
	}
	/// <summary>
	/// Problem: Child path is provided by name.
	/// We collect LibNodes and Child entities.
	/// Moving to use only the child.
	/// Problem: Once we start using the string Child,
	/// the calibre-images app bindings are out of sync.
	/// What about the MVC/JSON results?
	/// </summary>
	public class LibraryCollection
	{
		public List<string> Children { get;set; }
		public List<string> Ignore { get;set; }
		
		public DirectoryInfo BaseLibrary {
			get { return baseLibrary; }
			set { baseLibrary = value; }
		} DirectoryInfo baseLibrary;
		
		public DirectoryInfo BaseImages {
			get { return baseImages; }
			set { baseImages = value; }
		} DirectoryInfo baseImages;
		
		/// <summary>
		/// If Ignore is supplied, you don't need to supply pathNames as the filtered
		/// directories will be ignored, and items will automatically be generated.
		/// </summary>
		/// <param name="baseLib"></param>
		/// <param name="baseImg"></param>
		/// <param name="ignore"></param>
		/// <param name="pathNames"></param>
		public LibraryCollection(string baseLib, string baseImg, string[] ignore, params string[] pathNames)
		{
			this.Ignore = new List<string>();
			this.Children = new List<string>();
			if (ignore!=null) Ignore.AddRange(ignore);
			baseLibrary = new DirectoryInfo(baseLib);
			baseImages = new DirectoryInfo(baseImg);
			Add(pathNames);
		}
		
		#region Add Child
		/// <summary>
		/// Adds each item, then sorts them.
		/// </summary>
		/// <param name="pathNames"></param>
		public void Add(params string[] pathNames)
		{
			if (pathNames != null) foreach (var p in pathNames) Add(p);
			Children.Sort();
		}
		/// <summary>
		/// Add library if its not to be ignored.
		/// </summary>
		/// <param name="libraryName"></param>
		public void Add(string libraryName)
		{
			if (!Ignore.Contains(libraryName))
				Children.Add(libraryName);
		}
		#endregion
		#region Methods: LibNode
		/// <summary>
		/// FIXME: OBSOLETE
		/// This method is used when the output-directory path is changed.
		/// It filters out ignored items.
		/// </summary>
		/// <returns>directory-names as contained within the innerList</returns>
		List<LibNode> FilterNodes()
		{
			return GetNodes()
				.Where( n => !Ignore.Contains(n.Name) )
				.ToList();
		}
		List<LibNode> GetNodes()
		{
			return Children.ConvertAll<LibNode>(
				c=>new LibNode(){
					Library = new DirectoryInfo(Path.Combine(BaseLibrary.FullName, c)),
					Images = new DirectoryInfo(Path.Combine(BaseImages.FullName, c))
				});
//			this.ListItems.Sort((a, b) => string.Compare(a.ImagePath, b.ImagePath, StringComparison.Ordinal));
		}
		#endregion
		#region Methods: Reset Directory
		
		/// <summary>
		/// Enumerate all sub-directories containing metadata.db
		/// </summary>
		/// <param name="directory">
		/// Input library-root directory.
		/// Contains sub-directories with <tt>metadata.db</tt>.
		/// </param>
		/// <returns>a list of directory names</returns>
		List<string> GetDirectories(DirectoryInfo directory)
		{
			var directories = new List<string>();
			foreach (var info in directory.GetDirectories())
			{
				var files = info.GetFiles();
				var file = files.FirstOrDefault(c => c.Name == "metadata.db");
				if (file!=null)
					directories.Add(file.Directory.Name);
			}
			return directories;
		}
		
		/// <summary>
		/// Overload abstracting directory as stirng in stead of DirectoryInfo.
		/// </summary>
		/// <param name="directory">the new root-directory.</param>
		/// <param name="paths">optional.  if not set, we fall back on existing paths.</param>
		public void ResetBaseDirectory(string directory, params string[] paths)
		{
			ResetBaseDirectory(new DirectoryInfo(directory), paths);
		}
		
		/// <summary>
		/// If paths is provided, no need to <tt>directory.GetDirectories()</tt>.
		/// </summary>
		/// <param name="directory">the new root directory.</param>
		/// <param name="paths">optional.  if not set, we fall back on existing paths.</param>
		public void ResetBaseDirectory(DirectoryInfo directory, params string[] paths)
		{
			if (directory.Exists)
			{
			  BaseLibrary = directory;
			  // if paths is null then we recalculate the child directories
				var directories = paths==null ? GetDirectories(directory) : GetDirectoryNames();
				Children.Clear();
				Add(directories.ToArray());
				directories = null;
			}
		}
		
		/// <summary>
		/// This method is used when the output-directory path is changed.
		/// </summary>
		/// <returns>directory-names as contained within the innerList</returns>
		List<string> GetDirectoryNames()
		{
			return this.Children.ToList();
		}
		/// <summary>
		/// Reset the image output directory.
		/// The list is rebuilt when image-base directory changes.
		/// </summary>
		/// <param name="directory">the new image-root directory.</param>
		public void ResetOutputDirectory(string directory)
		{
			ResetOutputDirectory(new DirectoryInfo(directory));
		}
		/// <summary>
		/// Reset the image output directory.
		/// The list is rebuilt when image-base directory changes.
		/// </summary>
		/// <param name="directory">the new image-root directory.</param>
		public void ResetOutputDirectory(DirectoryInfo directory)
		{
			BaseImages = directory;
		}
		#endregion

	}
}







