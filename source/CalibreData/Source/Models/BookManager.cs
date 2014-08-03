/* oio * 7/25/2014 * Time: 7:23 PM */
using System;
using System.Collections.Generic;
using System.Cor3.Data.Engine;
using System.Data;
using System.Data.SQLite;
using System.IO;
using Newtonsoft.Json;
namespace CalibreData.Models
{
	public class BookManager
	{
		#region Static
		
		const string coverImageName = "cover.jpg", coverImageFilter = "{0:0000#}.jpg";
		
		static public void CloneImages(BookManager manager, DirectoryInfo destination)
		{
			string LibraryName = manager.LibraryPath.Name;
			foreach (var book in manager.BookCollection)
			{
				string source = GetCoverPath( manager , book );
				string outputFile = Path.Combine(
					destination.FullName,
					string.Format( coverImageFilter, book.id )
				);
				File.Copy( source, outputFile );
			}
		}
		
		static public string GetCoverPath(string startpath, Books book)
		{
			if (book.has_cover.HasValue && book.has_cover.Value)
				return string.Format("{0}{1:0000#}.jpg",startpath,book.id);
			return null;
		}
		static public string GetCoverPath(BookManager manager, Books book)
		{
			if (book.has_cover.HasValue && book.has_cover.Value)
				return Path.Combine(
					manager.LibraryPath.FullName,
					book.path,
					coverImageName
				).Replace("\\","/");
			return null;
		}
		
		#endregion
		
		public DirectoryInfo LibraryPath {
			get { return libraryPath; }
			set { libraryPath = value; }
		} DirectoryInfo libraryPath = null;
		
		public string SubPath {
			get { return subPath; }
			set { subPath = value; }
		} string subPath = null;
		
		Exception error = null;

		DataSet ds = null;

		#region Reference Content
		long Started, Ended;
		TimeSpan TimeCalculated;

		public List<BookModel> Master { get; set; }
		public List<Books> BookCollection { get; set; }
		public List<Comments> BookComments { get; set; }
		public List<Data> BookData { get; set; }
		public List<Authors> BookAuthors { get; set; }
		public List<Books_authors_link> LinkAuthors { get; set; }
		public List<Publishers> BookPublishers { get; set; }
		public List<Books_publishers_link> LinkPublishers { get; set; }
		public List<Tags> BookTags { get; set; }
		public List<Books_tags_link> LinkTags { get; set; }

		#endregion
		
		void GetData(string tableName, string query)
		{
			using (var db = new SQLiteDb(Path.Combine(LibraryPath.FullName, "metadata.db")))
			using (var c = db.Connection)
			using (var a = db.Adapter)
			using (var cmd = a.SelectCommand = new SQLiteCommand(query, c))
			{
				ds = new DataSet();
				ds.Tables.Add(tableName);
				c.Open();
				try {
					cmd.ExecuteNonQuery();
					a.Fill(ds, tableName);
				}
				catch (Exception e) {
					error = e;
				}
				finally {
					c.Close();
				}
			}
		}
		
		void CheckError() { if (this.error != null) throw error; }
		
		public BookManager(string subPath)
		{
			this.subPath = subPath;
			this.LibraryPath = new DirectoryInfo(System.IO.Path.Combine("f:/horde/library",SubPath));
			if (!LibraryPath.Exists) throw new DirectoryNotFoundException();
			this.Started = DateTime.Now.ToBinary();
			// 
			BookCollection = new List<Books>();
			GetData("books", Models.Books.Select_Books.Replace(";"," ORDER BY [sort];")); CheckError();
			foreach (DataRowView row in ds.Tables["books"].DefaultView) BookCollection.Add(row);
			// 
			BookData = new List<Data>();
			GetData("data", Data.Select_Data); CheckError();
			foreach (DataRowView row in ds.Tables["data"].DefaultView) BookData.Add(row);
			// 
			BookComments = new List<Comments>();
			GetData("comments", Comments.Select_Comments); CheckError();
			foreach (DataRowView row in ds.Tables["comments"].DefaultView) BookComments.Add(row);
			// 
			BookAuthors = new List<Authors>();
			GetData("auth", Authors.Select_Authors); CheckError();
			foreach (DataRowView row in ds.Tables["auth"].DefaultView) BookAuthors.Add(row);
			// 
			LinkAuthors = new List<Books_authors_link>();
			GetData("iauth", Books_authors_link.Select_Books_authors_link); CheckError();
			foreach (DataRowView row in ds.Tables["iauth"].DefaultView) LinkAuthors.Add(row);
			// 
			BookTags = new List<Tags>();
			GetData("tag", Tags.Select_Tags); CheckError();
			foreach (DataRowView row in ds.Tables["tag"].DefaultView) BookTags.Add(row);
			// 
			LinkTags = new List<Books_tags_link>();
			GetData("itag", Books_tags_link.Select_Books_tags_link); CheckError();
			foreach (DataRowView row in ds.Tables["itag"].DefaultView) LinkTags.Add(row);
			// 
			BookPublishers = new List<Publishers>();
			GetData("pub", Publishers.Select_Publishers); CheckError();
			foreach (DataRowView row in ds.Tables["pub"].DefaultView) BookPublishers.Add(row);
			// 
			LinkPublishers = new List<Books_publishers_link>();
			GetData("ipub", Books_publishers_link.Select_Books_publishers_link); CheckError();
			foreach (DataRowView row in ds.Tables["ipub"].DefaultView) LinkPublishers.Add(row);
			// 
			Master = new List<BookModel>();
			foreach (var item in this.BookCollection) Master.Add(new BookModel(this,item));
			// 
			this.Ended = DateTime.Now.ToBinary();
			DateTime dt = DateTime.FromBinary(Ended-Started);
			this.TimeCalculated = TimeSpan.FromTicks(dt.Ticks);
		}

		public string GetMasterJSON()
		{
//			var resultObject = ;
			string result = JsonConvert.SerializeObject(
				new {
					timeCalculated = this.TimeCalculated,
					data = this.Master,
					error = this.error == null ? (string)null : error.Message,
				});
			return result;
		}
		public string GetJSON()
		{
			var resultObject = new {
				started = this.Started,
				ended = this.Ended,
				error = this.error == null ? (string)null : error.Message,
				books = this.BookCollection
			};
			string result = JsonConvert.SerializeObject(resultObject);
			return result;
		}
	}
}



