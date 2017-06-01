/* oio * 7/25/2014 * Time: 7:23 PM */
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using CalibreData.Models;
namespace CalibreData
{
	
	/// <summary>
	/// <para>Process a single library.</para>
	/// <para>must be given a safe context in order to be safe: "use wisely."</para>
	/// </summary>
	public class CalibreImageWriter /* : IDisposable*/ // http://stackoverflow.com/questions/3873683/best-way-to-report-thread-progress ;-//
	{
		List<FileInfo> ProcessedFiles;
		List<FileInfo> UnprocessedFiles;
		
		public CalibreImageWriterOptions Options { get;set; }
		
		int Counter = 0;
		private Thread m_Thread;
		const string coverImageName = "cover.jpg", coverImageFilter = "{0:0000#}.jpg";
		BookManager manager;
		DirectoryInfo destination;

		public event EventHandler<ProgressEventArgs> Progress;
		public event EventHandler Complete;
//		bool IsCanceled = false; // were not supporting canceling.
		
		void ListMetainfo()
		{
		}
		
		public CalibreImageWriter (BookManager manager,
		                           DirectoryInfo destination,
		                           CalibreImageWriterOptions options
		                          )
		{
			Options = options;
			this.manager = manager;
			this.destination = destination;
			
			m_Thread = new Thread(Run);
			Counter = manager.Master.Count;
		}
		public CalibreImageWriter (BookManager manager, DirectoryInfo destination)
			:this(manager, destination, CalibreImageWriterOptions.Default)
		{
		}
		
		protected virtual void OnComplete()
		{
			var handler = Complete;
			if (handler != null) handler(this, EventArgs.Empty);
		}
		public void Start()
		{
			m_Thread.Priority = Options.ProcessPriority;
			m_Thread.Start();
		}

		private void Run()
		{
			string LibraryName = manager.LibraryPath.Name;
			
			UnprocessedFiles = destination.Exists ?
				new List<FileInfo>(destination.EnumerateFiles()) :
				UnprocessedFiles = new List<FileInfo>();
			
			
			if (Options.DeleteImagesBeforeCopy) foreach (var f in UnprocessedFiles) f.Delete();
			
			ProcessedFiles = new List<FileInfo>();
			bool HasCb = Options.Callback != null;
			
			for (int i = 0; i < manager.Master.Count; i++)
			{
				var book = manager.BookCollection[i];
				if (!book.has_cover.Value) {
					OnProgress(new ProgressEventArgs(i,Counter));
					continue;
				}
				
				string source = BookManager.GetCoverPath( manager , book );
				
				if (!destination.Exists && Options.CreateDirectoryIfNotExist)
					destination.Create();
				string outputFile = Path.Combine( destination.FullName, string.Format( coverImageFilter, book.id ) );
				
				if (HasCb) { Options.Callback(source,outputFile); }
				
				if (File.Exists(outputFile))
				{
					if (Options.OverwriteIfExist && Options.UseDefulatCallback && Options.DefaultCallback!=null)
						Options.DefaultCallback(source,outputFile);
				}
				else
				{
					if (Options.UseDefulatCallback && Options.DefaultCallback!=null)
						Options.DefaultCallback(source,outputFile);
				}
				
				OnProgress(new ProgressEventArgs(i,Counter));
			}
			OnComplete();
		}
		readonly object lockMe = new object();
		private void OnProgress(ProgressEventArgs args)
		{
			EventHandler<ProgressEventArgs> local;
			lock (lockMe) local = Progress;
			if (local != null) local(this, args);
			else Progress.DynamicInvoke(this, args);
		}

	}
}





