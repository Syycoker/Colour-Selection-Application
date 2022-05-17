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
            this.groupBackground = new System.Windows.Forms.GroupBox();
            this.cscBackground = new CustomUIControls.ColorSelectControl();
            this.groupBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBackground
            // 
            this.groupBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBackground.Controls.Add(this.cscBackground);
            this.groupBackground.Location = new System.Drawing.Point(5, 3);
            this.groupBackground.Name = "groupBackground";
            this.groupBackground.Size = new System.Drawing.Size(440, 68);
            this.groupBackground.TabIndex = 3;
            this.groupBackground.TabStop = false;
            this.groupBackground.Text = "Colour Picker";
            // 
            // cscBackground
            // 
            this.cscBackground.AccessibleDescription = "Select a color to use";
            this.cscBackground.AccessibleName = "Select Color";
            this.cscBackground.ControlID = 2;
            this.cscBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cscBackground.Location = new System.Drawing.Point(3, 18);
            this.cscBackground.Name = "cscBackground";
            this.cscBackground.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(191)))));
            this.cscBackground.Size = new System.Drawing.Size(434, 47);
            this.cscBackground.TabIndex = 0;
            // 
            // TextStylePicker
            // 
            this.Controls.Add(this.groupBackground);
            this.Name = "TextStylePicker";
            this.Size = new System.Drawing.Size(448, 78);
            this.Load += new System.EventHandler(this.OnFormLoad);
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
         //cscForeground.SelectedColor = m_ForeColor;
         cscBackground.SelectedColor = m_BackColor;

         // put ourselves in as callback
         //cscForeground.CallbackHost = this;
         cscBackground.CallbackHost = this;

         // update the preview
         //wndPreview.Font = m_Font;
         //wndPreview.ForeColor = m_ForeColor;
         //wndPreview.BackColor = m_BackColor;
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
     // public System.Drawing.Color SelectedForeColor
      //{
         //get
        // {
        //    return m_ForeColor;
        // }
        // set
         //{
       //     m_ForeColor = value;
        //    cscForeground.SelectedColor = m_ForeColor;
         //   UpdatePreview();
        // }
      //} // property SelectedForeColor

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
            ////wndPreview.BackColor = clrNewColor;
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
       //  Double.TryParse(wndFontSize.Text, System.Globalization.NumberStyles.Float, null,
       //     out dSize);
       //  FontStyle style = FontStyle.Regular;
       //  if (chkFontBold.Checked)
       //  {
       //     style |= FontStyle.Bold;
       //  }
       //  if (chkFontItalic.Checked)
       //  {
        //    style |= FontStyle.Italic;
        // }
        // if (chkFontUnderline.Checked)
        // {
        //    style |= FontStyle.Underline;
        // }
        // if (chkFontStrikeout.Checked)
        // {
        //    style |= FontStyle.Strikeout;
        // }
        // wndPreview.Font = new Font(wndFontFace.Text, (float) dSize, style);
        // wndPreview.BackColor = m_BackColor;
        // wndPreview.ForeColor = m_ForeColor;
        // m_Font = wndPreview.Font;
      } // UpdatePreview()

      /// <summary>
      /// Setup the controls to match the current font
      /// </summary>
      private void SetFontSelection()
      {
         // font face
       //  InstalledFontCollection fontSet = new InstalledFontCollection();
       //  FontFamily[] fontList = fontSet.Families;
       //  int SelIndex = 0;
       //  for (int ii = 0; ii < fontList.Length; ii++)
        // {
        //    if (fontList[ii].IsStyleAvailable(FontStyle.Bold) &&
         //      fontList[ii].IsStyleAvailable(FontStyle.Italic) &&
          //     fontList[ii].IsStyleAvailable(FontStyle.Underline) &&
           //    fontList[ii].IsStyleAvailable(FontStyle.Strikeout))
           // {
           //    int idx = wndFontFace.Items.Add(fontList[ii].Name);
           //    if (fontList[ii].Name == m_Font.Name)
            //   {
            //      SelIndex = idx;
            //   }
           // }
        // }
        // wndFontFace.SelectedIndex = SelIndex;

         // font size
        // ComboBox.ObjectCollection FontSizes = wndFontSize.Items;
        // string strSearch = m_Font.SizeInPoints.ToString("f");
        // SelIndex = FontSizes.IndexOf(strSearch);
        // if (SelIndex < 0)
         //{
        //    SelIndex = FontSizes.Add(strSearch);
        // }
        // wndFontSize.SelectedIndex = SelIndex;
      } // SetFontSelection()

      #endregion

   } // class TextStylePicker
} // namespace CustomUIControls
