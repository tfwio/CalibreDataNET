/* oio * 7/27/2014 * Time: 11:08 PM
 */
using System;
using System.IO;
using System.Windows.Forms;
namespace CopyCalibreCovers
{
	static class DragDropExtension
	{
		internal const string metaFormat1 = "data:{0};base64,{1}";
		
		static public string Base64Pack(string metaString, string inputFile, string outputFile)
		{
//			CheckForFileException.FileInput(inputFile);
			using (FileStream inputStream = File.Open(inputFile,FileMode.Open))
			{
				int bufferLength = Convert.ToInt32(inputStream.Length);
				byte[] buffer = new byte[bufferLength];
				inputStream.Read(buffer,0,bufferLength);
				string outputContent = string.Format(
					metaFormat1,
					metaString,
					Convert.ToBase64String(buffer)
				);
//				File.WriteAllText(outputFile, outputContent, System.Text.Encoding.UTF8);
				return outputContent;
			}
		}
		
		static void TInputDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
		}

		static void TInputDragDrop(object sender, DragEventArgs e)
		{
			var tInput = sender as TextBox;
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] strFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
				var f = new System.IO.DirectoryInfo(strFiles[0]);
				tInput.Text = f.FullName;
				strFiles = null;
			}
		}

		static public void ApplyDragDrop(this TextBox tb, DragEventHandler dragEnter = null, DragEventHandler dragDrop = null)
		{
			tb.AllowDrop = true;
			if (dragEnter != null) tb.DragEnter += new DragEventHandler(dragEnter);
			else tb.DragEnter += new DragEventHandler(TInputDragEnter);
			if (dragDrop != null) tb.DragDrop += new DragEventHandler(dragDrop);
			else tb.DragDrop += new DragEventHandler(TInputDragDrop);
		}
	}
}


