/* oio : 3/9/2014 6:29 AM */

// 
// this is/was just some sort of generated content
// using some generator tool or another.
// 
// that said, it would be nice to have some sort of
// generation device to generate some portion of our
// controller (in which case, perhaps maybe we would
// mark it as a `partial class`.
// 

using System;
using System.Web.Mvc;
using CalibreData.Models;

namespace BookApp.Controllers
{
	public class ApiController : Controller
	{
		void LoadELibrary(string subPath)
		{
			var bm = new BookManager(subPath);
			Response.ContentType = "application/json";
			Response.Write(bm.GetMasterJSON());
		}
		
		public ActionResult Books()
		{
			LoadELibrary(@"library, the");
			return null;
		}
		public ActionResult Dev()
		{
			LoadELibrary(@"library, dev");
			return null;
		}
		public ActionResult Ebook()
		{
			LoadELibrary(@"library, ebook");
			return null;
		}
		public ActionResult Ssoc()
		{
			LoadELibrary(@"library, ssoc");
			return null;
		}
		public ActionResult New()
		{
			LoadELibrary(@"library, new");
			return null;
		}
		public ActionResult Topical()
		{
			LoadELibrary(@"library, topical");
			return null;
		}
		public ActionResult Mag()
		{
			LoadELibrary(@"library, mag");
			return null;
		}
		public ActionResult Fiction()
		{
			LoadELibrary(@"library, fiction");
			return null;
		}
		public ActionResult Comic()
		{
			LoadELibrary(@"library, comic");
			return null;
		}
	}
}
