// *************************************************************************************** //
//  Created on 02/19/2005 by Kevin Menningen
//  This code is released to the public domain for any use, private or commercial.
//  You may modify this code and include it in any project. Please leave this comment
//  section in the code.
// *************************************************************************************** //

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Data;
using System.Windows.Forms;


namespace CustomUIControls
{
   /// <summary>
   /// A control that allows you to choose a foreground color, background color 
   /// and font for text.
   /// </summary>
   public class TextStylePicker : System.Windows.Forms.UserControl, IColorSelectCallback
   {
      //////////////////////////////////////////////////////////////////////////////////////
      // Data Members
      //////////////////////////////////////////////////////////////////////////////////////
      #region Data Members and Constants
      private const int FOREGROUND_ID = 1;
      private const int BACKGROUND_ID = 2;

      // Members
      private Font   m_Font;
      private Color  m_ForeColor;
      private Color  m_BackColor;

      // Windows
      private System.Windows.Forms.Label wndPreview;
      private System.Windows.Forms.GroupBox groupFont;
      private System.Windows.Forms.ComboBox wndFontFace;
      private System.Windows.Forms.ComboBox wndFontSize;
      private System.Windows.Forms.CheckBox chkFontBold;
      private System.Windows.Forms.CheckBox chkFontItalic;
      private System.Windows.Forms.CheckBox chkFontUnderline;
      private System.Windows.Forms.CheckBox chkFontStrikeout;
      private System.Windows.Forms.Label lblFont;
      private System.Windows.Forms.Label lblFontSize;
      private System.Windows.Forms.GroupBox groupForeground;
      private ColorSelectControl cscForeground;
      private System.Windows.Forms.GroupBox groupBackground;
      private ColorSelectControl cscBackground;

      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      #endregion

      //////////////////////////////////////////////////////////////////////////////////////
      // Construction / Destruction
      //////////////////////////////////////////////////////////////////////////////////////
      #region Construction / Destruction
      public TextStylePicker()
      {
         // This call is required by the Windows.Forms Form Designer.
         InitializeComponent();

         m_Font = SystemInformation.MenuFont;
         m_ForeColor = SystemColors.ControlText;
         m_BackColor = SystemColors.Control;
      }

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

      #endregion

      //////////////////////////////////////////////////////////////////////////////////////
      // Component Code - Auto Generated
      //////////////////////////////////////////////////////////////////////////////////////
      #region Component Designer generated code
      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.wndPreview = new System.Windows.Forms.Label();
         this.groupFont = new System.Windows.Forms.GroupBox();
         this.lblFontSize = new System.Windows.Forms.Label();
         this.lblFont = new System.Windows.Forms.Label();
         this.chkFontStrikeout = new System.Windows.Forms.CheckBox();
         this.chkFontUnderline = new System.Windows.Forms.CheckBox();
         this.chkFontItalic = new System.Windows.Forms.CheckBox();
         this.chkFontBold = new System.Windows.Forms.CheckBox();
         this.wndFontSize = new System.Windows.Forms.ComboBox();
         this.wndFontFace = new System.Windows.Forms.ComboBox();
         this.groupForeground = new System.Windows.Forms.GroupBox();
         this.cscForeground = new CustomUIControls.ColorSelectControl();
         this.groupBackground = new System.Windows.Forms.GroupBox();
         this.cscBackground = new CustomUIControls.ColorSelectControl();
         this.groupFont.SuspendLayout();
         this.groupForeground.SuspendLayout();
         this.groupBackground.SuspendLayout();
         this.SuspendLayout();
         // 
         // wndPreview
         // 
         this.wndPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.wndPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.wndPreview.Location = new System.Drawing.Point(4, 4);
         this.wndPreview.Name = "wndPreview";
         this.wndPreview.Size = new System.Drawing.Size(440, 68);
         this.wndPreview.TabIndex = 0;
         this.wndPreview.Text = "How quickly daft jumping zebras vex. 1234567890. ,\"/<>~!@#$%^&*()-+=";
         this.wndPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // groupFont
         // 
         this.groupFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupFont.Controls.Add(this.lblFontSize);
         this.groupFont.Controls.Add(this.lblFont);
         this.groupFont.Controls.Add(this.chkFontStrikeout);
         this.groupFont.Controls.Add(this.chkFontUnderline);
         this.groupFont.Controls.Add(this.chkFontItalic);
         this.groupFont.Controls.Add(this.chkFontBold);
         this.groupFont.Controls.Add(this.wndFontSize);
         this.groupFont.Controls.Add(this.wndFontFace);
         this.groupFont.Location = new System.Drawing.Point(4, 80);
         this.groupFont.Name = "groupFont";
         this.groupFont.Size = new System.Drawing.Size(440, 72);
         this.groupFont.TabIndex = 1;
         this.groupFont.TabStop = false;
         this.groupFont.Text = "Font";
         // 
         // lblFontSize
         // 
         this.lblFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.lblFontSize.Location = new System.Drawing.Point(304, 24);
         this.lblFontSize.Name = "lblFontSize";
         this.lblFontSize.Size = new System.Drawing.Size(84, 21);
         this.lblFontSize.TabIndex = 2;
         this.lblFontSize.Text = "Font si&ze:";
         this.lblFontSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // lblFont
         // 
         this.lblFont.Location = new System.Drawing.Point(8, 24);
         this.lblFont.Name = "lblFont";
         this.lblFont.Size = new System.Drawing.Size(48, 21);
         this.lblFont.TabIndex = 0;
         this.lblFont.Text = "&Font:";
         this.lblFont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // chkFontStrikeout
         // 
         this.chkFontStrikeout.Location = new System.Drawing.Point(332, 52);
         this.chkFontStrikeout.Name = "chkFontStrikeout";
         this.chkFontStrikeout.Size = new System.Drawing.Size(104, 16);
         this.chkFontStrikeout.TabIndex = 7;
         this.chkFontStrikeout.Text = "Stri&keout";
         this.chkFontStrikeout.CheckedChanged += new System.EventHandler(this.chkFontStrikeout_CheckedChanged);
         // 
         // chkFontUnderline
         // 
         this.chkFontUnderline.Location = new System.Drawing.Point(116, 52);
         this.chkFontUnderline.Name = "chkFontUnderline";
         this.chkFontUnderline.Size = new System.Drawing.Size(104, 16);
         this.chkFontUnderline.TabIndex = 5;
         this.chkFontUnderline.Text = "&Underline";
         this.chkFontUnderline.CheckedChanged += new System.EventHandler(this.chkFontUnderline_CheckedChanged);
         // 
         // chkFontItalic
         // 
         this.chkFontItalic.Location = new System.Drawing.Point(224, 52);
         this.chkFontItalic.Name = "chkFontItalic";
         this.chkFontItalic.Size = new System.Drawing.Size(104, 16);
         this.chkFontItalic.TabIndex = 6;
         this.chkFontItalic.Text = "&Italic";
         this.chkFontItalic.CheckedChanged += new System.EventHandler(this.chkFontItalic_CheckedChanged);
         // 
         // chkFontBold
         // 
         this.chkFontBold.Location = new System.Drawing.Point(8, 52);
         this.chkFontBold.Name = "chkFontBold";
         this.chkFontBold.Size = new System.Drawing.Size(104, 16);
         this.chkFontBold.TabIndex = 4;
         this.chkFontBold.Text = "&Bold";
         this.chkFontBold.CheckedChanged += new System.EventHandler(this.chkFontBold_CheckedChanged);
         // 
         // wndFontSize
         // 
         this.wndFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.wndFontSize.Items.AddRange(new object[] {
                                                         "6",
                                                         "8",
                                                         "9",
                                                         "10",
                                                         "12",
                                                         "14",
                                                         "16",
                                                         "18",
                                                         "20",
                                                         "24",
                                                         "28",
                                                         "32",
                                                         "36",
                                                         "40",
                                                         "44",
                                                         "48"});
         this.wndFontSize.Location = new System.Drawing.Point(388, 24);
         this.wndFontSize.Name = "wndFontSize";
         this.wndFontSize.Size = new System.Drawing.Size(48, 21);
         this.wndFontSize.TabIndex = 3;
         this.wndFontSize.Text = "10";
         this.wndFontSize.TextChanged += new System.EventHandler(this.OnFontSizeTextChanged);
         // 
         // wndFontFace
         // 
         this.wndFontFace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.wndFontFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.wndFontFace.Location = new System.Drawing.Point(56, 24);
         this.wndFontFace.MaxDropDownItems = 16;
         this.wndFontFace.Name = "wndFontFace";
         this.wndFontFace.Size = new System.Drawing.Size(244, 21);
         this.wndFontFace.TabIndex = 1;
         this.wndFontFace.TextChanged += new System.EventHandler(this.OnFontFaceChanged);
         this.wndFontFace.SelectedValueChanged += new System.EventHandler(this.OnFontFaceChanged);
         // 
         // groupForeground
         // 
         this.groupForeground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupForeground.Controls.Add(this.cscForeground);
         this.groupForeground.Location = new System.Drawing.Point(4, 160);
         this.groupForeground.Name = "groupForeground";
         this.groupForeground.Size = new System.Drawing.Size(440, 68);
         this.groupForeground.TabIndex = 2;
         this.groupForeground.TabStop = false;
         this.groupForeground.Text = "Text Color";
         // 
         // cscForeground
         // 
         this.cscForeground.AccessibleDescription = "Select a color to use";
         this.cscForeground.AccessibleName = "Select Color";
         this.cscForeground.ControlID = 1;
         this.cscForeground.Dock = System.Windows.Forms.DockStyle.Fill;
         this.cscForeground.Location = new System.Drawing.Point(3, 16);
         this.cscForeground.Name = "cscForeground";
         this.cscForeground.SelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(54)), ((System.Byte)(54)), ((System.Byte)(191)));
         this.cscForeground.Size = new System.Drawing.Size(434, 49);
         this.cscForeground.TabIndex = 0;
         // 
         // groupBackground
         // 
         this.groupBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBackground.Controls.Add(this.cscBackground);
         this.groupBackground.Location = new System.Drawing.Point(4, 232);
         this.groupBackground.Name = "groupBackground";
         this.groupBackground.Size = new System.Drawing.Size(440, 68);
         this.groupBackground.TabIndex = 3;
         this.groupBackground.TabStop = false;
         this.groupBackground.Text = "Background Color";
         // 
         // cscBackground
         // 
         this.cscBackground.AccessibleDescription = "Select a color to use";
         this.cscBackground.AccessibleName = "Select Color";
         this.cscBackground.ControlID = 2;
         this.cscBackground.Dock = System.Windows.Forms.DockStyle.Fill;
         this.cscBackground.Location = new System.Drawing.Point(3, 16);
         this.cscBackground.Name = "cscBackground";
         this.cscBackground.SelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(54)), ((System.Byte)(54)), ((System.Byte)(191)));
         this.cscBackground.Size = new System.Drawing.Size(434, 49);
         this.cscBackground.TabIndex = 0;
         // 
         // TextStylePicker
         // 
         this.Controls.Add(this.groupBackground);
         this.Controls.Add(this.groupForeground);
         this.Controls.Add(this.groupFont);
         this.Controls.Add(this.wndPreview);
         this.Name = "TextStylePicker";
         this.Size = new System.Drawing.Size(448, 304);
         this.Load += new System.EventHandler(this.OnFormLoad);
         this.groupFont.ResumeLayout(false);
         this.groupForeground.ResumeLayout(false);
         this.groupBackground.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      //////////////////////////////////////////////////////////////////////////////////////
      // Windows Event Handlers
      //////////////////////////////////////////////////////////////////////////////////////
      #region Windows Event Handlers
      /// <summary>
      /// Form is being loaded
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void OnFormLoad(object sender, System.EventArgs e)
      {
         // setup the font control
         SetFontSelection();

         // set the starting colors
         cscForeground.SelectedColor = m_ForeColor;
         cscBackground.SelectedColor = m_BackColor;

         // put ourselves in as callback
         cscForeground.CallbackHost = this;
         cscBackground.CallbackHost = this;

         // update the preview
         wndPreview.Font = m_Font;
         wndPreview.ForeColor = m_ForeColor;
         wndPreview.BackColor = m_BackColor;
      }

      private void chkFontBold_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdatePreview();
      }

      private void chkFontUnderline_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdatePreview();
      }

      private void chkFontItalic_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdatePreview();
      }

      private void chkFontStrikeout_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdatePreview();
      }

      private void OnFontSizeTextChanged(object sender, System.EventArgs e)
      {
         UpdatePreview();
      }

      private void OnFontFaceChanged(object sender, System.EventArgs e)
      {
         UpdatePreview();
      }

      #endregion

      //////////////////////////////////////////////////////////////////////////////////////
      // Public Properties
      //////////////////////////////////////////////////////////////////////////////////////
      #region Public Properties

      /// <summary>
      /// The font for the text
      /// </summary>
      public System.Drawing.Font SelectedFont
      {
         get
         {
            return m_Font;
         }
         set
         {
            m_Font = value;
            SetFontSelection();
            UpdatePreview();
         }
      } // property SelectedFont

      /// <summary>
      /// The foreground (text) color for the text
      /// </summary>
      public System.Drawing.Color SelectedForeColor
      {
         get
         {
            return m_ForeColor;
         }
         set
         {
            m_ForeColor = value;
            cscForeground.SelectedColor = m_ForeColor;
            UpdatePreview();
         }
      } // property SelectedForeColor

      /// <summary>
      /// The background color for the text
      /// </summary>
      public System.Drawing.Color SelectedBackColor
      {
         get
         {
            return m_BackColor;
         }
         set
         {
            m_BackColor = value;
            cscBackground.SelectedColor = m_BackColor;
            UpdatePreview();
         }
      } // property SelectedBackColor

      #endregion

      //////////////////////////////////////////////////////////////////////////////////////
      // Interface Implementation
      //////////////////////////////////////////////////////////////////////////////////////
      #region IColorSelectCallback Members

      /// <summary>
      /// One of the custom color select controls has changed its color
      /// </summary>
      /// <param name="ControlID">The unique ID of the control that changed</param>
      /// <param name="clrNewColor">The new color</param>
      public void ColorChanged(int ControlID, Color clrNewColor)
      {
         if (ControlID == FOREGROUND_ID)
         {
            wndPreview.ForeColor = clrNewColor;
            m_ForeColor = clrNewColor;
         }
         if (ControlID == BACKGROUND_ID)
         {
            wndPreview.BackColor = clrNewColor;
            m_BackColor = clrNewColor;
         }
      } // ColorChanged()

      #endregion

      //////////////////////////////////////////////////////////////////////////////////////
      // Private Methods
      //////////////////////////////////////////////////////////////////////////////////////   
      #region Private Methods

      /// <summary>
      /// Update the preview window to match the current settings
      /// </summary>
      private void UpdatePreview()
      {
         double dSize = 8;
         Double.TryParse(wndFontSize.Text, System.Globalization.NumberStyles.Float, null,
            out dSize);
         FontStyle style = FontStyle.Regular;
         if (chkFontBold.Checked)
         {
            style |= FontStyle.Bold;
         }
         if (chkFontItalic.Checked)
         {
            style |= FontStyle.Italic;
         }
         if (chkFontUnderline.Checked)
         {
            style |= FontStyle.Underline;
         }
         if (chkFontStrikeout.Checked)
         {
            style |= FontStyle.Strikeout;
         }
         wndPreview.Font = new Font(wndFontFace.Text, (float) dSize, style);
         wndPreview.BackColor = m_BackColor;
         wndPreview.ForeColor = m_ForeColor;
         m_Font = wndPreview.Font;
      } // UpdatePreview()

      /// <summary>
      /// Setup the controls to match the current font
      /// </summary>
      private void SetFontSelection()
      {
         // font face
         InstalledFontCollection fontSet = new InstalledFontCollection();
         FontFamily[] fontList = fontSet.Families;
         int SelIndex = 0;
         for (int ii = 0; ii < fontList.Length; ii++)
         {
            if (fontList[ii].IsStyleAvailable(FontStyle.Bold) &&
               fontList[ii].IsStyleAvailable(FontStyle.Italic) &&
               fontList[ii].IsStyleAvailable(FontStyle.Underline) &&
               fontList[ii].IsStyleAvailable(FontStyle.Strikeout))
            {
               int idx = wndFontFace.Items.Add(fontList[ii].Name);
               if (fontList[ii].Name == m_Font.Name)
               {
                  SelIndex = idx;
               }
            }
         }
         wndFontFace.SelectedIndex = SelIndex;

         // font size
         ComboBox.ObjectCollection FontSizes = wndFontSize.Items;
         string strSearch = m_Font.SizeInPoints.ToString("f");
         SelIndex = FontSizes.IndexOf(strSearch);
         if (SelIndex < 0)
         {
            SelIndex = FontSizes.Add(strSearch);
         }
         wndFontSize.SelectedIndex = SelIndex;
      } // SetFontSelection()

      #endregion

   } // class TextStylePicker
} // namespace CustomUIControls
