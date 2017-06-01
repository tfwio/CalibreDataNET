/* oio * 7/27/2014 * Time: 11:08 PM */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CalibreData
{
	static public class ImagePathToJSON
	{
		static readonly string[] exts = {
			".png",
			".jpg"
		};
		static public string Command(params string[] args)
		{
			if (args != null) {
				
				// a directory
				var dir = new System.IO.DirectoryInfo(args[0]);
				var files = dir.GetFiles()
					.Where(a=>exts.Contains(a.Extension.ToLower()))
					.OrderBy(a=>a.FullName)
					.ToList()
					.ConvertAll(a => new {file= a.Name} )
					;
				string returnValue = Newtonsoft.Json.JsonConvert
					.SerializeObject(
//						new{
//							basePath=dir.FullName,
						files
//						}
					);
				files.Clear();
				files = null;
				dir = null;
				return returnValue;
			}
			return null;
		}
	}
}




