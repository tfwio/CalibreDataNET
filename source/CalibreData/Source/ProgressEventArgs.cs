/* oio * 7/25/2014 * Time: 7:23 PM */
using System;
namespace CalibreData
{
	public class ProgressEventArgs : EventArgs
	{
		public MinMax MinMax {
			get;
			set;
		}

		public ProgressEventArgs(int min, int max)
		{
			MinMax = new MinMax(min, max);
		}
	}
}







