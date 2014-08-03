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
			this.tbOutputPath = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.nJpegQual = new System.Windows.Forms.NumericUpDown();
			this.nHeight = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.nWidth = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.label1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.nJpegQual)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nHeight)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nWidth)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnGo
			// 
			this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGo.Location = new System.Drawing.Point(416, 90);
			this.btnGo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(135, 29);
			this.btnGo.TabIndex = 6;
			this.btnGo.Text = "Refresh Binding";
			this.btnGo.UseVisualStyleBackColor = true;
			this.btnGo.Click += new System.EventHandler(this.BtnGoClick);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(416, 163);
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
			this.tbInputPath.Location = new System.Drawing.Point(101, 15);
			this.tbInputPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tbInputPath.Name = "tbInputPath";
			this.tbInputPath.Size = new System.Drawing.Size(450, 29);
			this.tbInputPath.TabIndex = 0;
			// 
			// tbOutputPath
			// 
			this.tbOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutputPath.Location = new System.Drawing.Point(101, 52);
			this.tbOutputPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tbOutputPath.Name = "tbOutputPath";
			this.tbOutputPath.Size = new System.Drawing.Size(450, 29);
			this.tbOutputPath.TabIndex = 7;
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(153, 90);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(256, 29);
			this.comboBox1.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 27);
			this.label2.TabIndex = 10;
			this.label2.Text = "Library";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 27);
			this.label3.TabIndex = 11;
			this.label3.Text = "Images";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 90);
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
			this.nJpegQual.Size = new System.Drawing.Size(95, 29);
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
			this.nHeight.Location = new System.Drawing.Point(251, 0);
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
			this.nHeight.Size = new System.Drawing.Size(95, 29);
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
			this.label5.Location = new System.Drawing.Point(346, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(98, 21);
			this.label5.TabIndex = 15;
			this.label5.Text = "; Jpeg Qual: ";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoSize = true;
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.nWidth);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.nHeight);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.nJpegQual);
			this.panel1.Location = new System.Drawing.Point(12, 127);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(539, 31);
			this.panel1.TabIndex = 16;
			// 
			// button3
			// 
			this.button3.Dock = System.Windows.Forms.DockStyle.Left;
			this.button3.Location = new System.Drawing.Point(48, 0);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(48, 31);
			this.button3.TabIndex = 19;
			this.button3.Text = "-";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button2
			// 
			this.button2.Dock = System.Windows.Forms.DockStyle.Left;
			this.button2.Location = new System.Drawing.Point(0, 0);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(48, 31);
			this.button2.TabIndex = 18;
			this.button2.Text = "+";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// nWidth
			// 
			this.nWidth.Dock = System.Windows.Forms.DockStyle.Right;
			this.nWidth.Location = new System.Drawing.Point(138, 0);
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
			this.nWidth.Size = new System.Drawing.Size(95, 29);
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
			this.label6.Location = new System.Drawing.Point(233, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(18, 21);
			this.label6.TabIndex = 17;
			this.label6.Text = "x";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.label1,
			this.progressBar1});
			this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.statusStrip1.Location = new System.Drawing.Point(0, 211);
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 233);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tbOutputPath);
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.NumericUpDown nWidth;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown nJpegQual;
		private System.Windows.Forms.NumericUpDown nHeight;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tbOutputPath;
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.ToolStripStatusLabel label1;
		private System.Windows.Forms.ToolStripProgressBar progressBar1;
		private System.Windows.Forms.TextBox tbInputPath;
	}
}
