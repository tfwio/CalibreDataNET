/* oio : 3/9/2014 6:29 AM */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Web.Mvc;
using CalibreData.Models;

namespace BookApp.Controllers
{
	public class ApiController : Controller
	{
		const string libroot = "f:/horde/library";
		
		static readonly List<string> CatApproved = new List<string>()
		{
			"library, the",
			"library, comic",
			"library, dev",
			"library, ebook",
			"library, fiction",
			"library, mag",
			"library, new",
			"library, ssoc",
			"library, topical"
		};
		
		void LoadELibrary(string subPath)
		{
			var bm = new BookManager(libroot,subPath.ToLower());
			Response.ContentType = "application/json";
			Response.Write(bm.GetMasterJSON());
		}
		
		/// <summary>
		/// The MIME/TYPE is significant here.
		/// We'll be serving files here most likely a stream object.
		/// </summary>
		/// <returns></returns>
		public ActionResult Book()
		{
			BookRequest book = null;
			Response.ContentType = "application/json";
			try {
				book = this.GetBook();
			} catch {
				Response.Write(this.Request.Path);
			}
			if (!CatApproved.Contains(book.Category.ToLower()))
			{
				Response.Write(
					string.Format("No such record for: {0}",this.Request.Path)
				);
			}
			const string mytable = "table";
			
			// books b inner join data d on b.[id] = d.[book]
			string query = @"
SELECT
	b.[id],
	b.[path],
	d.[name],
	d.[format]
FROM
(
	[books] b
	inner join [data] d
	on b.[id] = d.[book]
)
WHERE b.[id] = {ID}
AND d.[format] = '{FMT}'
;"
				.Replace("{ID}",book.BookId)
				.Replace("{FMT}",book.Format.ToUpper());
			string fileName = null;
			Data b = null;
			string p = System.IO.Path.Combine( libroot,book.Category,"metadata.db");
			using (var db = new SQLiteQuery(p) )
				using (var data = db.ExecuteSelect(query, mytable))
			{
				try {
//					b = data.Tables[mytable].DefaultView[0];
					object[] a =data.Tables[mytable].DefaultView[0].Row.ItemArray;
					fileName = string.Format("{1}/{2}.{3}",a[0],a[1],a[2],(a[3] as string) .ToLower());
					a = null;
				}
				catch (Exception e) {
//					Response.Write(
//						string.Format("No records found for query: {0}\r\nPath: {1}\r\n{2}\r\n",query,p,e)
//					);
				}
			}
			if (!string.IsNullOrEmpty(fileName)){
				//header('Connection: Keep-Alive');
				//header('Expires: 0');
//				Response.Headers.Add("Content-Description","File Transfer");
				Response.Headers.Add("Content-Type","application/octet-stream");
//				Response.Headers.Add("Content-Type","application/octet-stream");
//				Response.Headers.Add("Content-Disposition","attachment; filename=\"{0}\"");
				Response.Headers.Add("Content-Disposition",string.Format("attachment; filename=\"{0}\"",fileName));
//				Response.Headers.Add("Content-Transfer-Encoding","binary");
				Response.Headers.Add("Cache-Control","must-revalidate, post-check=0, pre-check=0");
//				Response.Headers.Add("Pragma","public");
//				Response.ContentType = "application/"+book.Format.ToLower();
				Response.WriteFile(System.IO.Path.Combine(libroot,book.Category,fileName),false);
			}
			return null;
		}__VALUES__

	}
	static class BookControllerExtensions
	{
		static public BookRequest GetBook(this Controller c)
		{
			//bookapp/api/book/1234/pdf/
			string[] vars = c.Request.Path.Split('/');
			return vars.Length != 7 ? new BookRequest() {
				Category = "error", BookId = "error", Format = "error"
			} : new BookRequest(vars[4],vars[5],vars[6]);
		}
	}
}
