/* oio * 7/25/2014 * Time: 7:23 PM */
using System;
namespace CalibreData
{
	public class MinMax
	{
		public int MinValue {
			get;
			set;
		}

		public int MaxValue {
			get;
			set;
		}

		public float PercentValue {
			get {
				return Convert.ToSingle(MinValue) / MaxValue;
			}
		}

		public MinMax(int min, int max)
		{
			this.MinValue = min;
			this.MaxValue = max;
		}
	}
}







