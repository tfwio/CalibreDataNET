using System;
namespace CalibreData.Models
{
	[System.Runtime.Serialization.DataContract]
	public class InfoModel
	{
		[System.Runtime.Serialization.DataMember]
		public string action {
			get;
			set;
		}

		[System.Runtime.Serialization.DataMember]
		public string libroot {
			get;
			set;
		}

		[System.Runtime.Serialization.DataMember]
		public string imgroot {
			get;
			set;
		}

		[System.Runtime.Serialization.DataMember]
		public string[] dirs {
			get;
			set;
		}

		[System.Runtime.Serialization.DataMember]
		public string[] ignore {
			get;
			set;
		}
	}
}

