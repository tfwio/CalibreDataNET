/* oio * 7/25/2014 * Time: 7:23 PM
 */
using System;
using System.Data;
using System.Data.SQLite;
namespace CalibreData.Models
{
	public class BookRequest
	{
	  static public void SetRoot(string library_root_path)
	  {
	    BookRequest.libroot = library_root_path;
	  }
		#region Constants
		// 
		// FIXME: this should be modular
		// 
		static string libroot = @"f:\horde\library";
		
		
		const string mytable = "table";
		const string query_book = @"
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
;";
		#endregion
		
		public string GetFileName()
		{
			string fileName = null;
			var query = query_book
				.Replace("{ID}",this.BookId)
				.Replace("{FMT}",this.Format.ToUpper());
			string p = System.IO.Path.Combine(libroot, Category, "metadata.db");
			using (var db = new System.Cor3.Data.Engine.SQLiteQuery(p) )
				using (var data = db.ExecuteSelect(query, mytable))
			{
				try {
					object[] a = data.Tables[mytable].DefaultView[0].Row.ItemArray;
					fileName = string.Format("{1}/{2}.{3}",a[0],a[1],a[2],(a[3] as string) .ToLower());
					a = null;
				}
				catch (Exception) { /* shhhhhhh! */ }
			}
			
			return fileName;
			
		}
		
		long Id { get { return string.IsNullOrEmpty(BookId) ? 0 : Convert.ToInt64(BookId); } }

		public string Category { get; set; }

		public string BookId { get; set; }

		public string Format { get; set; }

		public BookRequest(string cat, string id, string fmt)
		{
			this.Category = cat;
			this.BookId = id;
			this.Format = fmt;
		}

		public BookRequest()
		{
		}
	}
}

