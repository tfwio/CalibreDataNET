/* oio * 7/27/2014 * Time: 11:08 PM */
using System;
using System.IO;
using System.Windows.Forms;
using CalibreData;
using CalibreData.Models;

namespace CopyCalibreCovers
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public CoverSettings Options = new CoverSettings(){
			Libraries = new LibraryCollection(
				@"f:/Horde/Library", @"d:/dev/www/pub/books/assets", // subdirectories
				"Library, Comic", "Library, Dev", "Library, Ebook",
				"Library, Fiction", "Library, Images", "Library, Mag",
				"Library, New", "Library, SSOC", "Library, The", "Library, Topical"
			)};
		
		void GotProgress ( object sender, ProgressEventArgs args)
		{
			progressBar1.Value = args.MinMax.MinValue+1;
			label1.Text = string.Format("{0:##0}%",args.MinMax.PercentValue*100);
		}
		void GotComplete ( object sender, EventArgs args)
		{
			btnGo.Enabled = true;
			tbInputPath.Enabled = true;
			tbOutputPath.Enabled = true;
			label1.Text = "...";
			this.progressBar1.Maximum = 2;
			this.progressBar1.Value = 1;
		}
		
		void Event_Go(object sender, EventArgs args)
		{
			Options.SelectedLibrary = comboBox1.SelectedValue as LibNode;
			Options.JpegQuality = Convert.ToInt64(nJpegQual.Value);
			Options.CoverSize.X = Convert.ToSingle(nJpegQual.Value);
			Options.CoverSize.Y = Convert.ToSingle(nHeight.Value);
			
			Options.SelectedLibrary = comboBox1.SelectedValue as LibNode;
			
			if (Options.SelectedLibrary==null) return;
			
			DirectoryInfo DirectoryPath = Options.SelectedLibrary.Library;
			DirectoryInfo OutputPath = Options.SelectedLibrary.Images;
			
			if (!DirectoryPath.Exists) return;
			// if (!OutputPath.Exists) return;
			
			var bm = new BookManager(DirectoryPath.FullName);
			CalibreImageWriterOptions options = CalibreImageWriterOptions.Default;
			options.DefaultCallback = Options.MakeJpegCover;
			
			var writer = new CalibreImageWriter(bm,OutputPath,options);
			
			writer.Progress += GotProgress;
			writer.Complete += GotComplete;
			
			btnGo.Enabled = false;
			tbInputPath.Enabled = false;
			tbOutputPath.Enabled = false;
			
			progressBar1.Minimum = 1;
			progressBar1.Maximum = bm.Master.Count;
			
			label1.Text = "in progress";
			writer.Start();
		}
		
		public MainForm()
		{
			InitializeComponent();
			tbInputPath.ApplyDragDrop();
			tbOutputPath.ApplyDragDrop();
			BindingsReset();
		}
		void BindingsClear()
		{
			this.tbInputPath.DataBindings.Clear();
			this.tbOutputPath.DataBindings.Clear();
			this.comboBox1.DataSource = null;
		}
		void BindingsReset()
		{
			comboBox1.DisplayMember = "Name";
			comboBox1.DataSource= Options.Libraries;
			this.tbInputPath.DataBindings.Add(new Binding("Text",comboBox1,"SelectedValue.LibraryPath"));
			this.tbOutputPath.DataBindings.Add(new Binding("Text",comboBox1,"SelectedValue.ImagePath"));
		}
		void Button2Click(object sender, EventArgs e)
		{
			BindingsClear();
			Options.Libraries.Add("Another1");
			BindingsReset();
		}
		void Button3Click(object sender, EventArgs e)
		{
			int id = comboBox1.SelectedIndex;
			BindingsClear();
			Options.Libraries.RemoveAt(id);
			BindingsReset();
		}
		void BtnRefreshBindings(object sender, EventArgs e)
		{
			BindingsClear();
			BindingsReset();
		}
		void NHeightValueChanged(object sender, EventArgs e)
		{
			nWidth.Value = (long)Convert.ToInt32(nHeight.Value / 8 * 5);
		}
	}
}
