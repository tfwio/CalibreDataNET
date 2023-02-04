/* oio * 7/27/2014 * Time: 11:08 PM */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
		#region Variables
		const string test_info_filter = @"Path info:
libroot: {0}
imgroot: {1}
ignore[array]: {2}
dirs[array]: {3}";



		static readonly Newtonsoft.Json.JsonSerializerSettings JsonConfig =
			new Newtonsoft.Json.JsonSerializerSettings()
		{
		};

		public CoverSettings Options = new CoverSettings();
		
		static FolderBrowserDialog FBD = new FolderBrowserDialog(){
			Description =
				"Select a folder containing your Calibre libraries\n" +
				"—One directory above the actual ‘library/metadata.db’"
		};
		static FolderBrowserDialog IBD = new FolderBrowserDialog(){
			Description =
				"Select a destination-directory for library-images.\n" +
				"—In this directory, we will create a sub-directory containing generated images.’",
			ShowNewFolderButton=true
		};
    #endregion
    void InitializeJSON()
    {
      string data = System.IO.File.ReadAllText("conf.json");

      var model = Newtonsoft.Json.JsonConvert

				.DeserializeObject(
					data,
					typeof(InfoModel),
					JsonConfig

				) as InfoModel;

      Options.Libraries = new LibraryCollection(
        model.libroot,
        model.imgroot,
        model.ignore,
        model.dirs
      );

      // List<string> data1 = new List<string>(model.dirs);
      // data1.Insert(0, "dirs-start");
      // data1.Add("dirs-terminal");
      // MessageBox.Show(
      //   string.Format(test_info_filter, model.libroot, model.imgroot, model.ignore, string.Join("\", \"", data1.ToArray())), "testing");


    }
    
		public MainForm()
		{
			InitializeComponent();

      tbInputPath.ApplyDragDrop();
      tbImageRootPath.ApplyDragDrop();
      cbProcessAffinity.DataSource = Enum.GetValues(typeof(System.Threading.ThreadPriority));

      BindingsReset();
		}

		#region Process
		void GotProgress ( object sender, ProgressEventArgs args)
		{
      progressBar1.Value = args.MinMax.MinValue + 1;
      label1.Text = string.Format("{0:##0}%", args.MinMax.PercentValue * 100);
		}

		void GotComplete ( object sender, EventArgs args)
		{
			btnGo.Enabled = true;
			tbInputPath.Enabled = true;
			label1.Text = "...";
			this.progressBar1.Maximum = 2;
			this.progressBar1.Value = 1;
		}
		
		void Event_Go(object sender, EventArgs args)
		{
			Options.JpegQuality = Convert.ToInt64(nJpegQual.Value);
			Options.CoverSize.X = Convert.ToSingle(nJpegQual.Value);
			Options.CoverSize.Y = Convert.ToSingle(nHeight.Value);
			
			DirectoryInfo DirectoryPath = Options.Libraries.BaseLibrary;
			DirectoryInfo OutputPath = new DirectoryInfo(
				Path.Combine(Options.Libraries.BaseImages.FullName,comboBox1.Text));
			
			if (!DirectoryPath.Exists) return;
			
			var bm = new BookManager(Options.Libraries.BaseLibrary.FullName,comboBox1.Text);
			CalibreImageWriterOptions options = CalibreImageWriterOptions.Default;
			
			options.DefaultCallback = Options.MakeJpegCover;
			options.OverwriteIfExist = rOverwrite.Checked;
			options.DeleteImagesBeforeCopy = rOverwrite.Checked;
			options.ProcessPriority = (System.Threading.ThreadPriority)cbProcessAffinity.SelectedValue;
			
			var writer = new CalibreImageWriter(bm,OutputPath,options);
			
			writer.Progress += GotProgress;
			writer.Complete += GotComplete;
			
			btnGo.Enabled = false;
			tbInputPath.Enabled = false;
			
			progressBar1.Minimum = 1;
			progressBar1.Maximum = bm.Master.Count;
			
			label1.Text = "in progress";
			writer.Start();
		}
		#endregion
		
		#region Bindings

		void BindingsClear()
		{
			this.tbInputPath.DataBindings.Clear();
			this.tbImageRootPath.DataBindings.Clear();
			this.comboBox1.DataSource = null;
		}

		void BindingsReset()
    {
      InitializeJSON();

      comboBox1.DataSource = Options.Libraries.Children;


			this.tbInputPath.DataBindings.Add(new Binding("Text",Options.Libraries.BaseLibrary,"FullName"));
			this.tbImageRootPath.DataBindings.Add(new Binding("Text",Options.Libraries.BaseImages,"FullName"));
		}

		void BtnRefreshBindings(object sender, EventArgs e)
		{
			BindingsClear();
			BindingsReset();
		}

		#endregion

    // not adequate
		void On_Button_Library_Add(object sender, EventArgs e)
		{
			BindingsClear();
			// am not remembering if this leads to something that actually works...
			Options.Libraries.Add("Another1");
			BindingsReset();
		}

    // not adequate
		void On_Button_Library_Remove(object sender, EventArgs e)
		{
			int id = comboBox1.SelectedIndex;
			BindingsClear();
			Options.Libraries.Children.RemoveAt(id);
			BindingsReset();
		}

		#region Cover Width and Height
		void NHeightValueChanged(object sender, EventArgs e)
		{
			nWidth.Value = (long)Convert.ToInt32(nHeight.Value / 8 * 5);
		}
//		void NWidthValueChanged(object sender, EventArgs e)
//		{
//			nWidth.Value = (long)Convert.ToInt32(nHeight.Value / 5 * 8);
//		}
		#endregion

    void On_Button_Change_Inputs(object sender, EventArgs e) { On_Button_Change_Inputs(); }
		void On_Button_Change_Inputs()
		{
      BindingsClear();
			if (Options.Libraries.BaseLibrary.Exists)
				FBD.SelectedPath = Options.Libraries.BaseLibrary.FullName;
			if (FBD.ShowDialog()==DialogResult.OK)
				Options.Libraries.ResetBaseDirectory(FBD.SelectedPath);
			BindingsReset();
		}
    
		void On_Button_Change_Outputs(object sender, EventArgs e) { On_Button_Change_Outputs(); } // tbImageRootPath.Text = Options.Libraries.BaseImages.FullName;
		void On_Button_Change_Outputs()
		{
			if (Options.Libraries.BaseImages.Exists)
				IBD.SelectedPath = Options.Libraries.BaseImages.FullName;
			if (IBD.ShowDialog()==DialogResult.OK)
			{
				if (Directory.Exists(IBD.SelectedPath))
					Options.Libraries.ResetOutputDirectory(IBD.SelectedPath);
			}
      BindingsClear();
      BindingsReset();
		}
		
	}
}
