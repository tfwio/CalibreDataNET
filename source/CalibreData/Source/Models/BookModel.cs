/* oio * 7/25/2014 * Time: 7:23 PM */
using System;
using System.Collections.Generic;
using System.Linq;
using CalibreData.Models;
namespace CalibreData.Models
{
	// The Cleve "Backster Effect" (Clive?
	// book: "Get the life you want" --- subj: Mesmer-ism
	
	public class BookModel
	{
		BookManager Parent { get; set; }
		
		public Books BOOK { get;set; }
		
		public string Comment { get; set; }
		Comments Comments { get; set; }
		
		public List<Publishers> Publishers { get; set; }
		public List<Authors> Authors { get; set; }
		public List<Tags> Tags { get; set; }
		public List<Data> Formats { get; set; }
		
		public string CoverPath { get; set; }
//		Bitmap Cover { get; set; }
		string CoverPathGetter {
			get {
				return BookManager.GetCoverPath(
						string.Format(
							"/assets/{0}/",
							Parent.SubPath/*.Replace("library","images")*/),
						this.BOOK
					);
			}
		}
		
		public BookModel(BookManager manager, Books book)
		{
			this.Parent = manager;
			this.BOOK = book;
			
			this.Comments = manager.BookComments.FirstOrDefault(c => BOOK.id == c.book);
			this.Comment = Comments==null ? null : Comments.text;
			
			if (this.Parent==null) throw new NullReferenceException("Parent (BookManager) was null.");
			if (this.BOOK==null) throw new NullReferenceException("BOOK (Book) was null.");
			
			this.CoverPath = CoverPathGetter;
			this.Formats = new List<Data>();
			
			foreach (var link in manager.BookData.Where( pi => pi.book == book.id )) this.Formats.Add(link);
			this.Publishers = new List<Publishers>();
			
			foreach (var link in manager.LinkPublishers.Where( pi => pi.book == book.id ))
			foreach (var item in manager.BookPublishers.Where( p => p.id == link.publisher )) Publishers.Add(item);
			
			this.Authors = new List<Authors>();
			foreach (var link in manager.LinkAuthors.Where( pi => pi.book == book.id ))
			foreach (var item in manager.BookAuthors.Where( p => p.id == link.author )) Authors.Add(item);
			
			this.Tags = new List<Tags>();
			foreach (var link in manager.LinkTags.Where( pi => pi.book == book.id ))
			foreach (var item in manager.BookTags.Where( p => p.id == link.tag )) Tags.Add(item);
			
		}
	}
}

