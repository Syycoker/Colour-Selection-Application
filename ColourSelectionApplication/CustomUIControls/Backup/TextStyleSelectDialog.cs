// *************************************************************************************** //
//  Created on 02/19/2005 by Kevin Menningen
//  This code is released to the public domain for any use, private or commercial.
//  You may modify this code and include it in any project. Please leave this comment
//  section in the code.
// *************************************************************************************** //

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace CustomUIControls
{
   /// <summary>
   /// This dialog simply hosts the TextStylePicker control and returns any new settings
   /// if the user clicks OK.
   /// </summary>
   public class TextStyleSelectDialog : System.Windows.Forms.Form
   {
      //////////////////////////////////////////////////////////////////////////////////////
      // Data Members
      //////////////////////////////////////////////////////////////////////////////////////
      #region Data Members

      // members
      Font      m_OriginalFont;
      Font      m_SelectedFont;

      Color     m_OriginalForeColor;
      Color     m_SelectedForeColor;

      Color     m_OriginalBackColor;
      Color     m_SelectedBackColor;

      // controls
      private TextStylePicker wndStylePicker;
      private System.Windows.Forms.Label lblCurrent;
      private System.Windows.Forms.Label wndCurrentStyle;
      private System.Windows.Forms.Label lblNew;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnOK;

      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      #endregion

      //////////////////////////////////////////////////////////////////////////////////////
      // Construction / Destruction
      //////////////////////////////////////////////////////////////////////////////////////
      #region Construction / Destruction
      public TextStyleSelectDialog()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         m_OriginalFont = SystemInformation.MenuFont;
         m_OriginalForeColor = SystemColors.ControlText;
         m_OriginalBackColor = SystemColors.Control;
         m_SelectedFont = SystemInformation.MenuFont;
         m_SelectedForeColor = SystemColors.ControlText;
         m_SelectedBackColor = SystemColors.Control;
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
      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TextStyleSelectDialog));
         this.wndStylePicker = new TextStylePicker();
         this.lblCurrent = new System.Windows.Forms.Label();
         this.wndCurrentStyle = new System.Windows.Forms.Label();
         this.lblNew = new System.Windows.Forms.Label();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnOK = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // wndStylePicker
         // 
         this.wndStylePicker.Location = new System.Drawing.Point(8, 128);
         this.wndStylePicker.Name = "wndStylePicker";
         this.wndStylePicker.SelectedBackColor = System.Drawing.SystemColors.Control;
         this.wndStylePicker.SelectedFont = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
         this.wndStylePicker.SelectedForeColor = System.Drawing.SystemColors.ControlText;
         this.wndStylePicker.Size = new System.Drawing.Size(472, 316);
         this.wndStylePicker.TabIndex = 1;
         // 
         // lblCurrent
         // 
         this.lblCurrent.Location = new System.Drawing.Point(10, 12);
         this.lblCurrent.Name = "lblCurrent";
         this.lblCurrent.Size = new System.Drawing.Size(466, 16);
         this.lblCurrent.TabIndex = 2;
         this.lblCurrent.Text = "Current settings:";
         // 
         // wndCurrentStyle
         // 
         this.wndCurrentStyle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.wndCurrentStyle.Location = new System.Drawing.Point(12, 28);
         this.wndCurrentStyle.Name = "wndCurrentStyle";
         this.wndCurrentStyle.Size = new System.Drawing.Size(464, 68);
         this.wndCurrentStyle.TabIndex = 3;
         this.wndCurrentStyle.Text = "How quickly daft jumping zebras vex. 1234567890. ,\"/<>~!@#$%^&*()-+=";
         this.wndCurrentStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // lblNew
         // 
         this.lblNew.Location = new System.Drawing.Point(8, 112);
         this.lblNew.Name = "lblNew";
         this.lblNew.Size = new System.Drawing.Size(472, 16);
         this.lblNew.TabIndex = 4;
         this.lblNew.Text = "New settings:";
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(260, 460);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(108, 28);
         this.btnCancel.TabIndex = 5;
         this.btnCancel.Text = "&Cancel";
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(372, 460);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(108, 28);
         this.btnOK.TabIndex = 6;
         this.btnOK.Text = "&OK";
         // 
         // TextStyleSelectDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(492, 497);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.lblNew);
         this.Controls.Add(this.wndCurrentStyle);
         this.Controls.Add(this.lblCurrent);
         this.Controls.Add(this.wndStylePicker);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MinimizeBox = false;
         this.Name = "TextStyleSelectDialog";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
         this.Text = "Select Text Style";
         this.Load += new System.EventHandler(this.OnFormLoad);
         this.ResumeLayout(false);

      }
      #endregion

      //////////////////////////////////////////////////////////////////////////////////////
      // Windows Event Handlers
      //////////////////////////////////////////////////////////////////////////////////////
      #region Windows Event Handlers

      /// <summary>
      /// Form is loading, initialize controls
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void OnFormLoad(object sender, System.EventArgs e)
      {
         // setup the original settings view
         m_OriginalFont = m_SelectedFont;
         m_OriginalForeColor = m_SelectedForeColor;
         m_OriginalBackColor = m_SelectedBackColor;
         wndCurrentStyle.Font = m_OriginalFont;
         wndCurrentStyle.BackColor = m_OriginalBackColor;
         wndCurrentStyle.ForeColor = m_OriginalForeColor;
      }

      /// <summary>
      /// User is closing the dialog, see if they accepted the changes.
      /// </summary>
      /// <param name="e">Event arguments to let you prevent the dialog from closing</param>
      protected override void OnClosing(CancelEventArgs e)
      {
         base.OnClosing (e);
         if (base.DialogResult == DialogResult.OK)
         {
            m_SelectedFont = wndStylePicker.SelectedFont;
            m_SelectedForeColor = wndStylePicker.SelectedForeColor;
            m_SelectedBackColor = wndStylePicker.SelectedBackColor;
         }
      }

      #endregion

      //////////////////////////////////////////////////////////////////////////////////////
      // Public Properties
      //////////////////////////////////////////////////////////////////////////////////////
      #region Public Properties

      /// <summary>
      /// The font selected by the user
      /// </summary>
      public Font TextFont
      {
         get
         {
            return m_SelectedFont;
         }
         set
         {
            m_SelectedFont = value;
            wndStylePicker.SelectedFont = m_SelectedFont;
         }
      } // property TextFont

      /// <summary>
      /// The background color selected by the user
      /// </summary>
      public Color TextBackColor
      {
         get
         {
            return m_SelectedBackColor;
         }
         set
         {
            m_SelectedBackColor = value;
            wndStylePicker.SelectedBackColor = m_SelectedBackColor;
         }
      } // property TextBackColor

      /// <summary>
      /// The foreground color selected by the user
      /// </summary>
      public Color TextForeColor
      {
         get
         {
            return m_SelectedForeColor;
         }
         set
         {
            m_SelectedForeColor = value;
            wndStylePicker.SelectedForeColor = m_SelectedForeColor;
         }
      } // property TextForeColor

      #endregion
   } // class TextStyleSelectDialog
} // namespace CustomUIControls
