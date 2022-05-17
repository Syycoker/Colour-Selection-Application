
namespace ColourSelectionApplication
{
  partial class ColourForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColourForm));
      this.MainToolStrip = new System.Windows.Forms.ToolStrip();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.LoadButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.CreateButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.WidthTextBox = new System.Windows.Forms.ToolStripTextBox();
      this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
      this.HeightTextBox = new System.Windows.Forms.ToolStripTextBox();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.SaveButton = new System.Windows.Forms.ToolStripButton();
      this.SaveTextBox = new System.Windows.Forms.ToolStripTextBox();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ResetButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.ClearButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.CloseButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.RotateButton = new System.Windows.Forms.ToolStripButton();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.colorSelectControl1 = new CustomUIControls.ColorSelectControl();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.preset9 = new System.Windows.Forms.Panel();
      this.preset8 = new System.Windows.Forms.Panel();
      this.preset7 = new System.Windows.Forms.Panel();
      this.preset6 = new System.Windows.Forms.Panel();
      this.preset5 = new System.Windows.Forms.Panel();
      this.preset4 = new System.Windows.Forms.Panel();
      this.preset3 = new System.Windows.Forms.Panel();
      this.preset2 = new System.Windows.Forms.Panel();
      this.preset1 = new System.Windows.Forms.Panel();
      this.MainPanel = new System.Windows.Forms.Panel();
      this.UndoButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.MainToolStrip.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // MainToolStrip
      // 
      this.MainToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.LoadButton,
            this.toolStripSeparator7,
            this.CreateButton,
            this.toolStripLabel1,
            this.WidthTextBox,
            this.toolStripLabel2,
            this.HeightTextBox,
            this.toolStripSeparator1,
            this.SaveButton,
            this.SaveTextBox,
            this.toolStripSeparator2,
            this.ResetButton,
            this.toolStripSeparator3,
            this.ClearButton,
            this.toolStripSeparator5,
            this.CloseButton,
            this.toolStripSeparator6,
            this.RotateButton,
            this.toolStripSeparator8,
            this.UndoButton});
      this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
      this.MainToolStrip.Name = "MainToolStrip";
      this.MainToolStrip.Size = new System.Drawing.Size(907, 25);
      this.MainToolStrip.TabIndex = 0;
      this.MainToolStrip.Text = "toolStrip1";
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
      // 
      // LoadButton
      // 
      this.LoadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.LoadButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadButton.Image")));
      this.LoadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.LoadButton.Name = "LoadButton";
      this.LoadButton.Size = new System.Drawing.Size(37, 22);
      this.LoadButton.Text = "Load";
      this.LoadButton.Click += new System.EventHandler(this.HandleLoadGrid);
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
      // 
      // CreateButton
      // 
      this.CreateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.CreateButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateButton.Image")));
      this.CreateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CreateButton.Name = "CreateButton";
      this.CreateButton.Size = new System.Drawing.Size(45, 22);
      this.CreateButton.Text = "Create";
      this.CreateButton.Click += new System.EventHandler(this.HandleCreateGrid);
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
      this.toolStripLabel1.Text = "Width";
      // 
      // WidthTextBox
      // 
      this.WidthTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.WidthTextBox.Name = "WidthTextBox";
      this.WidthTextBox.Size = new System.Drawing.Size(86, 25);
      this.WidthTextBox.Text = "8";
      // 
      // toolStripLabel2
      // 
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new System.Drawing.Size(43, 22);
      this.toolStripLabel2.Text = "Height";
      // 
      // HeightTextBox
      // 
      this.HeightTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.HeightTextBox.Name = "HeightTextBox";
      this.HeightTextBox.Size = new System.Drawing.Size(86, 25);
      this.HeightTextBox.Text = "8";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // SaveButton
      // 
      this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
      this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.SaveButton.Name = "SaveButton";
      this.SaveButton.Size = new System.Drawing.Size(35, 22);
      this.SaveButton.Text = "Save";
      this.SaveButton.Click += new System.EventHandler(this.HandleSaveGrid);
      // 
      // SaveTextBox
      // 
      this.SaveTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.SaveTextBox.Name = "SaveTextBox";
      this.SaveTextBox.Size = new System.Drawing.Size(86, 25);
      this.SaveTextBox.TextChanged += new System.EventHandler(this.HandleNameChanged);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // ResetButton
      // 
      this.ResetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.ResetButton.Image = ((System.Drawing.Image)(resources.GetObject("ResetButton.Image")));
      this.ResetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ResetButton.Name = "ResetButton";
      this.ResetButton.Size = new System.Drawing.Size(39, 22);
      this.ResetButton.Text = "Reset";
      this.ResetButton.Click += new System.EventHandler(this.HandleReset);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // ClearButton
      // 
      this.ClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.ClearButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearButton.Image")));
      this.ClearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ClearButton.Name = "ClearButton";
      this.ClearButton.Size = new System.Drawing.Size(38, 22);
      this.ClearButton.Text = "Clear";
      this.ClearButton.Click += new System.EventHandler(this.HandleClear);
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
      // 
      // CloseButton
      // 
      this.CloseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
      this.CloseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CloseButton.Name = "CloseButton";
      this.CloseButton.Size = new System.Drawing.Size(40, 22);
      this.CloseButton.Text = "Close";
      this.CloseButton.Click += new System.EventHandler(this.HandleClose);
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
      // 
      // RotateButton
      // 
      this.RotateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.RotateButton.Image = ((System.Drawing.Image)(resources.GetObject("RotateButton.Image")));
      this.RotateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.RotateButton.Name = "RotateButton";
      this.RotateButton.Size = new System.Drawing.Size(65, 22);
      this.RotateButton.Text = "Rotate 90*";
      this.RotateButton.Click += new System.EventHandler(this.HandleGridRotate);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.MainPanel, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.52941F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.47059F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(907, 365);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.88413F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.11587F));
      this.tableLayoutPanel2.Controls.Add(this.colorSelectControl1, 0, 1);
      this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 1);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 263);
      this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.52174F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.47826F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(903, 100);
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // colorSelectControl1
      // 
      this.colorSelectControl1.AccessibleDescription = "Select a color to use";
      this.colorSelectControl1.AccessibleName = "Select Color";
      this.colorSelectControl1.ControlID = 0;
      this.colorSelectControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.colorSelectControl1.Location = new System.Drawing.Point(2, 18);
      this.colorSelectControl1.Margin = new System.Windows.Forms.Padding(2);
      this.colorSelectControl1.Name = "colorSelectControl1";
      this.colorSelectControl1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(191)))));
      this.colorSelectControl1.Size = new System.Drawing.Size(608, 80);
      this.colorSelectControl1.TabIndex = 5;
      this.colorSelectControl1.Load += new System.EventHandler(this.HandleColourControlLoaded);
      this.colorSelectControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HandleColourSelected);
      // 
      // label2
      // 
      this.label2.BackColor = System.Drawing.Color.White;
      this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label2.Location = new System.Drawing.Point(4, 0);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(604, 16);
      this.label2.TabIndex = 3;
      this.label2.Text = "Colour Selection";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.Color.White;
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(614, 0);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(287, 16);
      this.label1.TabIndex = 4;
      this.label1.Text = "Preset Colours";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.ColumnCount = 3;
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel3.Controls.Add(this.preset9, 2, 2);
      this.tableLayoutPanel3.Controls.Add(this.preset8, 1, 2);
      this.tableLayoutPanel3.Controls.Add(this.preset7, 0, 2);
      this.tableLayoutPanel3.Controls.Add(this.preset6, 2, 1);
      this.tableLayoutPanel3.Controls.Add(this.preset5, 1, 1);
      this.tableLayoutPanel3.Controls.Add(this.preset4, 0, 1);
      this.tableLayoutPanel3.Controls.Add(this.preset3, 2, 0);
      this.tableLayoutPanel3.Controls.Add(this.preset2, 1, 0);
      this.tableLayoutPanel3.Controls.Add(this.preset1, 0, 0);
      this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel3.Location = new System.Drawing.Point(614, 18);
      this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 3;
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel3.Size = new System.Drawing.Size(287, 80);
      this.tableLayoutPanel3.TabIndex = 6;
      // 
      // preset9
      // 
      this.preset9.Dock = System.Windows.Forms.DockStyle.Fill;
      this.preset9.Location = new System.Drawing.Point(192, 54);
      this.preset9.Margin = new System.Windows.Forms.Padding(2);
      this.preset9.Name = "preset9";
      this.preset9.Size = new System.Drawing.Size(93, 24);
      this.preset9.TabIndex = 8;
      this.preset9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandlePresetClicked);
      // 
      // preset8
      // 
      this.preset8.Dock = System.Windows.Forms.DockStyle.Fill;
      this.preset8.Location = new System.Drawing.Point(97, 54);
      this.preset8.Margin = new System.Windows.Forms.Padding(2);
      this.preset8.Name = "preset8";
      this.preset8.Size = new System.Drawing.Size(91, 24);
      this.preset8.TabIndex = 7;
      this.preset8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandlePresetClicked);
      // 
      // preset7
      // 
      this.preset7.Dock = System.Windows.Forms.DockStyle.Fill;
      this.preset7.Location = new System.Drawing.Point(2, 54);
      this.preset7.Margin = new System.Windows.Forms.Padding(2);
      this.preset7.Name = "preset7";
      this.preset7.Size = new System.Drawing.Size(91, 24);
      this.preset7.TabIndex = 6;
      this.preset7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandlePresetClicked);
      // 
      // preset6
      // 
      this.preset6.Dock = System.Windows.Forms.DockStyle.Fill;
      this.preset6.Location = new System.Drawing.Point(192, 28);
      this.preset6.Margin = new System.Windows.Forms.Padding(2);
      this.preset6.Name = "preset6";
      this.preset6.Size = new System.Drawing.Size(93, 22);
      this.preset6.TabIndex = 5;
      this.preset6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandlePresetClicked);
      // 
      // preset5
      // 
      this.preset5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.preset5.Location = new System.Drawing.Point(97, 28);
      this.preset5.Margin = new System.Windows.Forms.Padding(2);
      this.preset5.Name = "preset5";
      this.preset5.Size = new System.Drawing.Size(91, 22);
      this.preset5.TabIndex = 4;
      this.preset5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandlePresetClicked);
      // 
      // preset4
      // 
      this.preset4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.preset4.Location = new System.Drawing.Point(2, 28);
      this.preset4.Margin = new System.Windows.Forms.Padding(2);
      this.preset4.Name = "preset4";
      this.preset4.Size = new System.Drawing.Size(91, 22);
      this.preset4.TabIndex = 3;
      this.preset4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandlePresetClicked);
      // 
      // preset3
      // 
      this.preset3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.preset3.Location = new System.Drawing.Point(192, 2);
      this.preset3.Margin = new System.Windows.Forms.Padding(2);
      this.preset3.Name = "preset3";
      this.preset3.Size = new System.Drawing.Size(93, 22);
      this.preset3.TabIndex = 2;
      this.preset3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandlePresetClicked);
      // 
      // preset2
      // 
      this.preset2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.preset2.Location = new System.Drawing.Point(97, 2);
      this.preset2.Margin = new System.Windows.Forms.Padding(2);
      this.preset2.Name = "preset2";
      this.preset2.Size = new System.Drawing.Size(91, 22);
      this.preset2.TabIndex = 1;
      this.preset2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandlePresetClicked);
      // 
      // preset1
      // 
      this.preset1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.preset1.Location = new System.Drawing.Point(2, 2);
      this.preset1.Margin = new System.Windows.Forms.Padding(2);
      this.preset1.Name = "preset1";
      this.preset1.Size = new System.Drawing.Size(91, 22);
      this.preset1.TabIndex = 0;
      this.preset1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandlePresetClicked);
      // 
      // MainPanel
      // 
      this.MainPanel.AutoScroll = true;
      this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainPanel.Location = new System.Drawing.Point(2, 2);
      this.MainPanel.Margin = new System.Windows.Forms.Padding(2);
      this.MainPanel.Name = "MainPanel";
      this.MainPanel.Size = new System.Drawing.Size(903, 257);
      this.MainPanel.TabIndex = 1;
      // 
      // UndoButton
      // 
      this.UndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.UndoButton.Image = ((System.Drawing.Image)(resources.GetObject("UndoButton.Image")));
      this.UndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.UndoButton.Name = "UndoButton";
      this.UndoButton.Size = new System.Drawing.Size(40, 22);
      this.UndoButton.Text = "Undo";
      this.UndoButton.Click += new System.EventHandler(this.HandleUndo);
      // 
      // toolStripSeparator8
      // 
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
      // 
      // ColourForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(907, 390);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(this.MainToolStrip);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "ColourForm";
      this.Text = "Colour Selection Form";
      this.MainToolStrip.ResumeLayout(false);
      this.MainToolStrip.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip MainToolStrip;
    private System.Windows.Forms.ToolStripButton LoadButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton SaveButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton ResetButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripButton ClearButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripTextBox WidthTextBox;
    private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    private System.Windows.Forms.ToolStripTextBox HeightTextBox;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private CustomUIControls.ColorSelectControl colorSelectControl1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.Panel preset9;
    private System.Windows.Forms.Panel preset8;
    private System.Windows.Forms.Panel preset7;
    private System.Windows.Forms.Panel preset6;
    private System.Windows.Forms.Panel preset5;
    private System.Windows.Forms.Panel preset4;
    private System.Windows.Forms.Panel preset3;
    private System.Windows.Forms.Panel preset2;
    private System.Windows.Forms.Panel preset1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripButton CloseButton;
    private System.Windows.Forms.Panel MainPanel;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripTextBox SaveTextBox;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripButton CreateButton;
    private System.Windows.Forms.ToolStripButton RotateButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    private System.Windows.Forms.ToolStripButton UndoButton;
  }
}