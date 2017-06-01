/* oio * 7/27/2014 * Time: 11:08 PM */
using System;
using System.Drawing;
using CalibreData;
using CalibreData.Models;
namespace CopyCalibreCovers
{
	public class CoverSettings
	{
		public LibNode SelectedLibrary { get; set; }

		public LibraryCollection Libraries {
			get { return libraries; }
			set { libraries = value; }
		} LibraryCollection libraries;

		public FloatPoint CoverSize {
			get { return coverSize; }
			set { coverSize = value; }
		} FloatPoint coverSize = new FloatPoint(200, 320);

		public long JpegQuality {
			get { return jpegQuality; }
			set { jpegQuality = value; }
		} long jpegQuality = 90;

		public void MakeJpegCover(string src, string dst)
		{
			ImageExtensions.PathToResizeJpeg(src, dst, coverSize, jpegQuality);
		}
	}
}


