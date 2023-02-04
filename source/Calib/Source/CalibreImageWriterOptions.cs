/* oio * 7/25/2014 * Time: 7:23 PM */
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using CalibreData.Models;
namespace CalibreData
{
	public class CalibreImageWriterOptions
	{
		/// <summary>
		/// </summary>
		public ThreadPriority ProcessPriority
		{
			get;
			set;
		}
		
		/// <summary>
		/// Skips copying a particular image if it allready exists.
		/// </summary>
		public bool OverwriteIfExist {
			get;
			set;
		}
		
		/// <summary>
		/// This option deletes all images before all images are revenerated.
		/// </summary>
		public bool DeleteImagesBeforeCopy {
			get;
			set;
		}

		/// <summary>
		/// not implemented
		/// </summary>
		public bool CleanUnusedCoversAfterCopy {
			get;
			set;
		}
		
		/// <summary>
		/// not implemented
		/// </summary>
		public bool CreateDirectoryIfNotExist {
			get;
			set;
		}

		/// <summary>
		/// When true, skips the default copy method and uses callback (if defined).
		/// </summary>
		public bool UseDefulatCallback {
			get;
			set;
		}

		/// <summary>
		/// Param1: InputPath, Param2: OutputPath
		/// </summary>
		public Action<string, string> Callback {
			get;
			set;
		}

		/// <summary>
		/// File.Copy
		/// </summary>
		public Action<string, string> DefaultCallback {
			get;
			set;
		}

		static readonly public CalibreImageWriterOptions Default = new CalibreImageWriterOptions() {
			DeleteImagesBeforeCopy = true,
			CleanUnusedCoversAfterCopy = true,
			DefaultCallback = File.Copy,
			Callback = null,
			CreateDirectoryIfNotExist = true,
			UseDefulatCallback = true
		};
	}
}







