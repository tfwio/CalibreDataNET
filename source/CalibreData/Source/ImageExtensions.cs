/* oio * 7/25/2014 * Time: 7:23 PM */
using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace CalibreData
{
	static public class ImageExtensions
	{
		static public readonly ImageCodecInfo JpegCodecInfo = GetEncoder(ImageFormat.Jpeg);
		
		static ImageCodecInfo GetEncoder(ImageFormat format)
		{
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
			foreach (ImageCodecInfo codec in codecs) {
				if (codec.FormatID == format.Guid) {
					Console.WriteLine(codec.FormatID);
					return codec;
				}
			}
			return null;
		}

		static public void ExportJpeg(this System.Drawing.Bitmap bmp, string fileName, long QualityFactor)
		{
			var qualityEncoder = Encoder.Quality;
			var ratio = new EncoderParameter(qualityEncoder, QualityFactor);
			var codecParams = new EncoderParameters(1);
			codecParams.Param[0] = ratio;
			bmp.Save(fileName, JpegCodecInfo, codecParams);
			// Save to JPG
		}

		static object l = new object();

		static public Bitmap Resize(this Bitmap source, FloatPoint targetSize, Color bg)
		{
			var renderBitmap = new Bitmap((int)targetSize.X, (int)targetSize.Y);
			using (var g = Graphics.FromImage(renderBitmap)) {
				g.SetQuality(); // defaults to HQ-smoothing with HQ-Bicubic-interpolation
				g.Clear(bg);
				g.DrawImage(source, 0, 0, targetSize.X, targetSize.Y);
			}
			return renderBitmap;
		}
		static public void PathToResizeJpeg(string pathIn, string pathOut, FloatPoint sizeto, long qual = 90)
		{
			using (var b = new Bitmap(pathIn)) {
				var fp = b.Size;
				var fpd = FloatPoint.Fit(sizeto, fp, 3);
				using (var newimg = Resize(b, fpd, Color.Black))
					newimg.ExportJpeg(pathOut, qual);
			}
		}
	}
}







