/* oio : 3/9/2014 6:29 AM */
using System;
using System.Collections.Generic;
using System.Cor3.Data.Engine;
using System.Data;
using System.Diagnostics;
using System.Security;
using System.Linq;
using System.Web.Mvc;
using CalibreData.Models;

namespace BookApp.Controllers
{
	public class ApiController : Controller
	{
		internal const string libroot = @"e:\serve\book";
		
		// the intent here was to open up our index to variable input
		// so we don't need to write each library into our controller
		// as here we have overloaded LoadELibrary within each library
		// context such as "~/api/
		internal static readonly List<string> CatApproved = new List<string>(){
		"dev"
		};
		
		public void LoadELibrary(string subPath)
		{
			BookControllerExtensions.LoadELibrary(this,subPath);
		}
		
		public ActionResult Index()
		{
			ViewData["lib"] = RouteData.Values["library"];
			return View();
		}
		/// <summary>
		/// The MIME/TYPE is significant here.
		/// We'll be serving files here most likely a stream object.
		/// </summary>
		/// <returns></returns>
		public ActionResult Book()
		{
			BookRequest book = null;
			
			try {
				book = this.GetBook();
			} catch {
				Response.Write(this.Request.Path);
        return View();
			}
      Response.ContentType = "application/json";
			
			if (!CatApproved.Contains(book.Category.ToLower()))
			{
				Response.Write( string.Format("No such record for: {0}",this.Request.Path) );
			}
			
			string fileName = book.GetFileName();
			
			if (!string.IsNullOrEmpty(fileName))
			{
				// header('Connection: Keep-Alive');
				// header('Expires: 0');
        // Response.Headers.Add("Content-Description","File Transfer");
        // Response.Headers.Add("Content-Type","application/octet-stream");
        // Response.Headers.Add("Content-Disposition","attachment; filename=\"{0}\"");
        // if (Request["r"]==null)
				Response.Headers.Add("Content-Disposition",string.Format("attachment; filename=\"{0}\"",System.IO.Path.GetFileName(fileName)));
        // Response.Headers.Add("Content-Transfer-Encoding","binary");
        // Response.Headers.Add("Cache-Control","must-revalidate, post-check=0, pre-check=0");
				Response.ContentType = "application/"+book.Format.ToLower();
				Response.WriteFile(System.IO.Path.Combine(libroot,book.Category,fileName),false);
			}
			return null;
		}

    public ActionResult Books() { LoadELibrary(@"non-fiction"); return null; }
    public ActionResult Dev() { LoadELibrary(@"dev"); return null; }
    public ActionResult Ebook() { LoadELibrary(@"ebook"); return null; }
    public ActionResult Ssoc() { LoadELibrary(@"ssoc"); return null; }
    public ActionResult New() { LoadELibrary(@"new"); return null; }
    public ActionResult Mag() { LoadELibrary(@"mag"); return null; }
    public ActionResult Fiction() { LoadELibrary(@"fiction"); return null; }
    public ActionResult Comic() { LoadELibrary(@"comic"); return null; }
		
	}
	static public class BookControllerExtensions
	{
		public static void LoadELibrary(Controller controller, string subPath)
		{
			controller.Response.ContentType = "application/json";
			var bm = new BookManager(ApiController.libroot, subPath.ToLower());
			controller.Response.Write(bm.GetMasterJSON());
		}
		/// <summary>
		/// this can only be used from the ApiController.
		/// Its been too frigging long --- i really don't want to read this and don't remember what it does. ;)
		/// </summary>
		/// <param name="html"></param>
		/// <returns></returns>
		static public string TestMe(this System.Web.Mvc.HtmlHelper html)
		{
			var c = html.ViewContext.Controller as ApiController;
			
			string lib = c.RouteData.Values.Keys.Contains("library") ? c.RouteData.Values["library"].ToString() : "UNKNOWN LIBRARY";
			
			if (ApiController.CatApproved.Contains(lib.ToLower()))
			{
				var bm = new BookManager(ApiController.libroot,lib.ToLower());
				string fmt=@"We can now provide our information for “{0}”
<hr />
<pre style=""font-family: 'FreeMono', fixed-width; max-height: 10em; min-height: 10em; max-width: 500px; overflow: auto;""><code>{1}
</code></pre>";
				return string.Format(fmt,lib,bm.GetMasterJSON());
			}
			else
			{
				const string format = @"
we don't know what to say right now.<br/>
We have {0} route values.<br/>
We were expecting 4.<br/>
The ""controller"" value is {1}<br/>
The ""action"" value is {2}<br/>
The ""library"" value is {3}<br/>
The ""sort"" value is {4}<br/>

";
				return string.Format(
					format,
					c.RouteData.Values.Count,
					c.RouteData.Values["controller"] ?? "UNKNOWN",
					c.RouteData.Values["action"] ?? "UNKNOWN",
					c.RouteData.Values["library"] ?? "UNKNOWN",
					c.RouteData.Values["sort"] ?? "UNKNOWN"
				);
			}
		}
		/// <summary>
		/// testing
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		static public BookRequest GetBook(this Controller c)
		{
			//bookapp/api/book/1234/pdf/
			string[] vars = c.Request.AppRelativeCurrentExecutionFilePath.Split('/');
			Stack<string> svars = new Stack<string>(vars.Reverse());
			while (true)
			{
			  if (svars.Peek().ToLower()=="api") break;
        svars.Pop();
			}
			svars = new Stack<string>(svars);
			vars = svars.Reverse().ToArray();
			
			// there are a few ways this scenario can go in which case we end up with
			// a different number of potential path-segments here...
			
			// (1) IIS app-subdirectory
      //     - where `http://localhost/[myappname]/api/...
      // (2) IIS Express mode
			//     - where `http://localhost:8080/api/...
			// (3) IIS app-main mode (see above, but with or w/o the port ID)
			
			//api/book/dev/00116/pdf
			
			return vars.Length != 5 ? new BookRequest() {
				Category = "error",
				BookId = "error",
				Format = "error"
			} : new BookRequest(vars[2],vars[3],vars[4]);
		}
	}
}
