/* oio * 7/27/2014 * Time: 11:08 PM
 */
namespace CopyCalibreCovers
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
		  this.btnGo = new System.Windows.Forms.Button();
		  this.button1 = new System.Windows.Forms.Button();
		  this.tbInputPath = new System.Windows.Forms.TextBox();
		  this.comboBox1 = new System.Windows.Forms.ComboBox();
		  this.label2 = new System.Windows.Forms.Label();
		  this.label4 = new System.Windows.Forms.Label();
		  this.nJpegQual = new System.Windows.Forms.NumericUpDown();
		  this.nHeight = new System.Windows.Forms.NumericUpDown();
		  this.label5 = new System.Windows.Forms.Label();
		  this.panel1 = new System.Windows.Forms.Panel();
		  this.buttonRemoveSelection = new System.Windows.Forms.Button();
		  this.buttonAddSelection = new System.Windows.Forms.Button();
		  this.nWidth = new System.Windows.Forms.NumericUpDown();
		  this.label6 = new System.Windows.Forms.Label();
		  this.statusStrip1 = new System.Windows.Forms.StatusStrip();
		  this.label1 = new System.Windows.Forms.ToolStripStatusLabel();
		  this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
		  this.cbProcessAffinity = new System.Windows.Forms.ComboBox();
		  this.label7 = new System.Windows.Forms.Label();
		  this.rOverwrite = new System.Windows.Forms.RadioButton();
		  this.rMissing = new System.Windows.Forms.RadioButton();
		  this.buttonChangeRoot = new System.Windows.Forms.Button();
		  this.tbImageRootPath = new System.Windows.Forms.TextBox();
		  this.label8 = new System.Windows.Forms.Label();
		  this.buttonResetImageOutputPath = new System.Windows.Forms.Button();
		  this.menuStrip1 = new System.Windows.Forms.MenuStrip();
		  this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		  this.btnLoadConfig = new System.Windows.Forms.ToolStripMenuItem();
		  this.btnSaveConfig = new System.Windows.Forms.ToolStripMenuItem();
		  this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
		  this.refreshFromROOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		  this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		  ((System.ComponentModel.ISupportInitialize)(this.nJpegQual)).BeginInit();
		  ((System.ComponentModel.ISupportInitialize)(this.nHeight)).BeginInit();
		  this.panel1.SuspendLayout();
		  ((System.ComponentModel.ISupportInitialize)(this.nWidth)).BeginInit();
		  this.statusStrip1.SuspendLayout();
		  this.menuStrip1.SuspendLayout();
		  this.SuspendLayout();
		  // 
		  // btnGo
		  // 
		  this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		  this.btnGo.Location = new System.Drawing.Point(416, 108);
		  this.btnGo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		  this.btnGo.Name = "btnGo";
		  this.btnGo.Size = new System.Drawing.Size(135, 29);
		  this.btnGo.TabIndex = 6;
		  this.btnGo.Text = "Refresh Binding";
		  this.btnGo.UseVisualStyleBackColor = true;
		  this.btnGo.Click += new System.EventHandler(this.BtnRefreshBindings);
		  // 
		  // button1
		  // 
		  this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		  this.button1.Location = new System.Drawing.Point(416, 181);
		  this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		  this.button1.Name = "button1";
		  this.button1.Size = new System.Drawing.Size(135, 29);
		  this.button1.TabIndex = 8;
		  this.button1.Text = "Go";
		  this.button1.UseVisualStyleBackColor = true;
		  this.button1.Click += new System.EventHandler(this.Event_Go);
		  // 
		  // tbInputPath
		  // 
		  this.tbInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      | System.Windows.Forms.AnchorStyles.Right)));
		  this.tbInputPath.Location = new System.Drawing.Point(101, 37);
		  this.tbInputPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		  this.tbInputPath.Name = "tbInputPath";
		  this.tbInputPath.Size = new System.Drawing.Size(308, 27);
		  this.tbInputPath.TabIndex = 0;
		  // 
		  // comboBox1
		  // 
		  this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      | System.Windows.Forms.AnchorStyles.Right)));
		  this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		  this.comboBox1.FormattingEnabled = true;
		  this.comboBox1.Location = new System.Drawing.Point(153, 108);
		  this.comboBox1.Name = "comboBox1";
		  this.comboBox1.Size = new System.Drawing.Size(256, 27);
		  this.comboBox1.TabIndex = 9;
		  // 
		  // label2
		  // 
		  this.label2.Location = new System.Drawing.Point(12, 37);
		  this.label2.Name = "label2";
		  this.label2.Size = new System.Drawing.Size(82, 27);
		  this.label2.TabIndex = 10;
		  this.label2.Text = "Library";
		  this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		  // 
		  // label4
		  // 
		  this.label4.Location = new System.Drawing.Point(12, 108);
		  this.label4.Name = "label4";
		  this.label4.Size = new System.Drawing.Size(135, 27);
		  this.label4.TabIndex = 12;
		  this.label4.Text = "Library Collection";
		  this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		  // 
		  // nJpegQual
		  // 
		  this.nJpegQual.Dock = System.Windows.Forms.DockStyle.Right;
		  this.nJpegQual.Location = new System.Drawing.Point(444, 0);
		  this.nJpegQual.Minimum = new decimal(new int[] {
      20,
      0,
      0,
      0});
		  this.nJpegQual.Name = "nJpegQual";
		  this.nJpegQual.Size = new System.Drawing.Size(95, 27);
		  this.nJpegQual.TabIndex = 13;
		  this.nJpegQual.Value = new decimal(new int[] {
      90,
      0,
      0,
      0});
		  // 
		  // nHeight
		  // 
		  this.nHeight.Dock = System.Windows.Forms.DockStyle.Right;
		  this.nHeight.Location = new System.Drawing.Point(253, 0);
		  this.nHeight.Maximum = new decimal(new int[] {
      90000,
      0,
      0,
      0});
		  this.nHeight.Minimum = new decimal(new int[] {
      32,
      0,
      0,
      0});
		  this.nHeight.Name = "nHeight";
		  this.nHeight.Size = new System.Drawing.Size(95, 27);
		  this.nHeight.TabIndex = 14;
		  this.nHeight.Value = new decimal(new int[] {
      320,
      0,
      0,
      0});
		  this.nHeight.ValueChanged += new System.EventHandler(this.NHeightValueChanged);
		  // 
		  // label5
		  // 
		  this.label5.AutoSize = true;
		  this.label5.Dock = System.Windows.Forms.DockStyle.Right;
		  this.label5.Location = new System.Drawing.Point(348, 0);
		  this.label5.Name = "label5";
		  this.label5.Size = new System.Drawing.Size(96, 19);
		  this.label5.TabIndex = 15;
		  this.label5.Text = "; Jpeg Qual: ";
		  // 
		  // panel1
		  // 
		  this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      | System.Windows.Forms.AnchorStyles.Right)));
		  this.panel1.AutoSize = true;
		  this.panel1.Controls.Add(this.buttonRemoveSelection);
		  this.panel1.Controls.Add(this.buttonAddSelection);
		  this.panel1.Controls.Add(this.nWidth);
		  this.panel1.Controls.Add(this.label6);
		  this.panel1.Controls.Add(this.nHeight);
		  this.panel1.Controls.Add(this.label5);
		  this.panel1.Controls.Add(this.nJpegQual);
		  this.panel1.Location = new System.Drawing.Point(12, 145);
		  this.panel1.Name = "panel1";
		  this.panel1.Size = new System.Drawing.Size(539, 31);
		  this.panel1.TabIndex = 16;
		  // 
		  // buttonRemoveSelection
		  // 
		  this.buttonRemoveSelection.Dock = System.Windows.Forms.DockStyle.Left;
		  this.buttonRemoveSelection.Location = new System.Drawing.Point(48, 0);
		  this.buttonRemoveSelection.Name = "buttonRemoveSelection";
		  this.buttonRemoveSelection.Size = new System.Drawing.Size(48, 31);
		  this.buttonRemoveSelection.TabIndex = 19;
		  this.buttonRemoveSelection.Text = "-";
		  this.buttonRemoveSelection.UseVisualStyleBackColor = true;
		  this.buttonRemoveSelection.Click += new System.EventHandler(this.On_Button_Library_Remove);
		  // 
		  // buttonAddSelection
		  // 
		  this.buttonAddSelection.Dock = System.Windows.Forms.DockStyle.Left;
		  this.buttonAddSelection.Location = new System.Drawing.Point(0, 0);
		  this.buttonAddSelection.Name = "buttonAddSelection";
		  this.buttonAddSelection.Size = new System.Drawing.Size(48, 31);
		  this.buttonAddSelection.TabIndex = 18;
		  this.buttonAddSelection.Text = "+";
		  this.buttonAddSelection.UseVisualStyleBackColor = true;
		  this.buttonAddSelection.Click += new System.EventHandler(this.On_Button_Library_Add);
		  // 
		  // nWidth
		  // 
		  this.nWidth.Dock = System.Windows.Forms.DockStyle.Right;
		  this.nWidth.Location = new System.Drawing.Point(141, 0);
		  this.nWidth.Maximum = new decimal(new int[] {
      90000,
      0,
      0,
      0});
		  this.nWidth.Minimum = new decimal(new int[] {
      32,
      0,
      0,
      0});
		  this.nWidth.Name = "nWidth";
		  this.nWidth.Size = new System.Drawing.Size(95, 27);
		  this.nWidth.TabIndex = 16;
		  this.nWidth.Value = new decimal(new int[] {
      200,
      0,
      0,
      0});
		  // 
		  // label6
		  // 
		  this.label6.AutoSize = true;
		  this.label6.Dock = System.Windows.Forms.DockStyle.Right;
		  this.label6.Location = new System.Drawing.Point(236, 0);
		  this.label6.Name = "label6";
		  this.label6.Size = new System.Drawing.Size(17, 19);
		  this.label6.TabIndex = 17;
		  this.label6.Text = "x";
		  // 
		  // statusStrip1
		  // 
		  this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
      this.label1,
      this.progressBar1});
		  this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
		  this.statusStrip1.Location = new System.Drawing.Point(0, 253);
		  this.statusStrip1.Name = "statusStrip1";
		  this.statusStrip1.Size = new System.Drawing.Size(564, 22);
		  this.statusStrip1.TabIndex = 17;
		  this.statusStrip1.Text = "statusStrip1";
		  // 
		  // label1
		  // 
		  this.label1.Name = "label1";
		  this.label1.Size = new System.Drawing.Size(16, 17);
		  this.label1.Text = "...";
		  // 
		  // progressBar1
		  // 
		  this.progressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		  this.progressBar1.Name = "progressBar1";
		  this.progressBar1.Size = new System.Drawing.Size(100, 16);
		  // 
		  // cbProcessAffinity
		  // 
		  this.cbProcessAffinity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		  this.cbProcessAffinity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		  this.cbProcessAffinity.FormattingEnabled = true;
		  this.cbProcessAffinity.Location = new System.Drawing.Point(263, 182);
		  this.cbProcessAffinity.Name = "cbProcessAffinity";
		  this.cbProcessAffinity.Size = new System.Drawing.Size(146, 27);
		  this.cbProcessAffinity.TabIndex = 18;
		  // 
		  // label7
		  // 
		  this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		  this.label7.Location = new System.Drawing.Point(101, 186);
		  this.label7.Name = "label7";
		  this.label7.Size = new System.Drawing.Size(149, 23);
		  this.label7.TabIndex = 19;
		  this.label7.Text = "Process Affinity";
		  this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		  // 
		  // rOverwrite
		  // 
		  this.rOverwrite.AutoSize = true;
		  this.rOverwrite.Location = new System.Drawing.Point(12, 187);
		  this.rOverwrite.Name = "rOverwrite";
		  this.rOverwrite.Size = new System.Drawing.Size(91, 23);
		  this.rOverwrite.TabIndex = 21;
		  this.rOverwrite.Text = "overwrite";
		  this.rOverwrite.UseVisualStyleBackColor = true;
		  // 
		  // rMissing
		  // 
		  this.rMissing.AutoSize = true;
		  this.rMissing.Checked = true;
		  this.rMissing.Location = new System.Drawing.Point(12, 214);
		  this.rMissing.Name = "rMissing";
		  this.rMissing.Size = new System.Drawing.Size(117, 23);
		  this.rMissing.TabIndex = 22;
		  this.rMissing.TabStop = true;
		  this.rMissing.Text = "missing only";
		  this.rMissing.UseVisualStyleBackColor = true;
		  // 
		  // buttonChangeRoot
		  // 
		  this.buttonChangeRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		  this.buttonChangeRoot.Location = new System.Drawing.Point(416, 37);
		  this.buttonChangeRoot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		  this.buttonChangeRoot.Name = "buttonChangeRoot";
		  this.buttonChangeRoot.Size = new System.Drawing.Size(135, 29);
		  this.buttonChangeRoot.TabIndex = 23;
		  this.buttonChangeRoot.Text = "Change-Lib-Root";
		  this.buttonChangeRoot.UseVisualStyleBackColor = true;
		  this.buttonChangeRoot.Click += new System.EventHandler(this.On_Button_Change_Inputs);
		  // 
		  // tbImageRootPath
		  // 
		  this.tbImageRootPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      | System.Windows.Forms.AnchorStyles.Right)));
		  this.tbImageRootPath.Location = new System.Drawing.Point(101, 74);
		  this.tbImageRootPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		  this.tbImageRootPath.Name = "tbImageRootPath";
		  this.tbImageRootPath.Size = new System.Drawing.Size(308, 27);
		  this.tbImageRootPath.TabIndex = 0;
		  // 
		  // label8
		  // 
		  this.label8.Location = new System.Drawing.Point(12, 74);
		  this.label8.Name = "label8";
		  this.label8.Size = new System.Drawing.Size(82, 27);
		  this.label8.TabIndex = 10;
		  this.label8.Text = "Output";
		  this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		  // 
		  // buttonResetImageOutputPath
		  // 
		  this.buttonResetImageOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		  this.buttonResetImageOutputPath.Location = new System.Drawing.Point(416, 74);
		  this.buttonResetImageOutputPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		  this.buttonResetImageOutputPath.Name = "buttonResetImageOutputPath";
		  this.buttonResetImageOutputPath.Size = new System.Drawing.Size(135, 29);
		  this.buttonResetImageOutputPath.TabIndex = 23;
		  this.buttonResetImageOutputPath.Text = "Img-Out-Root";
		  this.buttonResetImageOutputPath.UseVisualStyleBackColor = true;
		  this.buttonResetImageOutputPath.Click += new System.EventHandler(this.On_Button_Change_Outputs);
		  // 
		  // menuStrip1
		  // 
		  this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
      this.fileToolStripMenuItem});
		  this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		  this.menuStrip1.Name = "menuStrip1";
		  this.menuStrip1.Size = new System.Drawing.Size(564, 24);
		  this.menuStrip1.TabIndex = 24;
		  this.menuStrip1.Text = "menuStrip1";
		  // 
		  // fileToolStripMenuItem
		  // 
		  this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
      this.btnLoadConfig,
      this.btnSaveConfig,
      this.toolStripMenuItem1,
      this.refreshFromROOTToolStripMenuItem,
      this.exitToolStripMenuItem});
		  this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
		  this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
		  this.fileToolStripMenuItem.Text = "File";
		  // 
		  // btnLoadConfig
		  // 
		  this.btnLoadConfig.Name = "btnLoadConfig";
		  this.btnLoadConfig.Size = new System.Drawing.Size(224, 22);
		  this.btnLoadConfig.Text = "Load Configuration (*.JSON)";
		  // 
		  // btnSaveConfig
		  // 
		  this.btnSaveConfig.Name = "btnSaveConfig";
		  this.btnSaveConfig.Size = new System.Drawing.Size(224, 22);
		  this.btnSaveConfig.Text = "Save Configuration";
		  // 
		  // toolStripMenuItem1
		  // 
		  this.toolStripMenuItem1.Name = "toolStripMenuItem1";
		  this.toolStripMenuItem1.Size = new System.Drawing.Size(221, 6);
		  // 
		  // refreshFromROOTToolStripMenuItem
		  // 
		  this.refreshFromROOTToolStripMenuItem.Name = "refreshFromROOTToolStripMenuItem";
		  this.refreshFromROOTToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
		  this.refreshFromROOTToolStripMenuItem.Text = "Refresh Library Root";
		  // 
		  // exitToolStripMenuItem
		  // 
		  this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
		  this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
		  this.exitToolStripMenuItem.Text = "Exit";
		  // 
		  // MainForm
		  // 
		  this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
		  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		  this.ClientSize = new System.Drawing.Size(564, 275);
		  this.Controls.Add(this.buttonResetImageOutputPath);
		  this.Controls.Add(this.buttonChangeRoot);
		  this.Controls.Add(this.rMissing);
		  this.Controls.Add(this.rOverwrite);
		  this.Controls.Add(this.label7);
		  this.Controls.Add(this.cbProcessAffinity);
		  this.Controls.Add(this.statusStrip1);
		  this.Controls.Add(this.menuStrip1);
		  this.Controls.Add(this.panel1);
		  this.Controls.Add(this.label4);
		  this.Controls.Add(this.label8);
		  this.Controls.Add(this.label2);
		  this.Controls.Add(this.comboBox1);
		  this.Controls.Add(this.button1);
		  this.Controls.Add(this.tbImageRootPath);
		  this.Controls.Add(this.btnGo);
		  this.Controls.Add(this.tbInputPath);
		  this.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		  this.MinimumSize = new System.Drawing.Size(580, 271);
		  this.Name = "MainForm";
		  this.Text = "CopyCalibreCovers";
		  ((System.ComponentModel.ISupportInitialize)(this.nJpegQual)).EndInit();
		  ((System.ComponentModel.ISupportInitialize)(this.nHeight)).EndInit();
		  this.panel1.ResumeLayout(false);
		  this.panel1.PerformLayout();
		  ((System.ComponentModel.ISupportInitialize)(this.nWidth)).EndInit();
		  this.statusStrip1.ResumeLayout(false);
		  this.statusStrip1.PerformLayout();
		  this.menuStrip1.ResumeLayout(false);
		  this.menuStrip1.PerformLayout();
		  this.ResumeLayout(false);
		  this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem btnSaveConfig;
		private System.Windows.Forms.ToolStripMenuItem refreshFromROOTToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem btnLoadConfig;
		private System.Windows.Forms.TextBox tbImageRootPath;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button buttonResetImageOutputPath;
		private System.Windows.Forms.Button buttonChangeRoot;
		private System.Windows.Forms.RadioButton rOverwrite;
		private System.Windows.Forms.RadioButton rMissing;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbProcessAffinity;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Button buttonRemoveSelection;
		private System.Windows.Forms.Button buttonAddSelection;
		private System.Windows.Forms.NumericUpDown nWidth;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown nJpegQual;
		private System.Windows.Forms.NumericUpDown nHeight;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.ToolStripStatusLabel label1;
		private System.Windows.Forms.ToolStripProgressBar progressBar1;
		private System.Windows.Forms.TextBox tbInputPath;
	}
}
