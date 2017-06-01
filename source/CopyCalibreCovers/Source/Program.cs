/* oio * 7/27/2014 * Time: 11:08 PM
 */
using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
namespace CopyCalibreCovers
{
	
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
