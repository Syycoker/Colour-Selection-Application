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
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace CustomUIControls
{
   /// <summary>
   /// ColorSelectControl - A control that lets the user rapidly select a color by picking
   /// a specific hue, then adjusting luminance/brightness and saturation to tweak it. The 
   /// user may also left click on the selected color area to get the more precise but 
   /// clumsier color pick dialog provided by Windows.
   /// </summary>
   [ToolboxBitmap(typeof(Button))]
   public class ColorSelectControl : System.Windows.Forms.UserControl
   {
      //////////////////////////////////////////////////////////////////////////////////////
      // Data Members
      //////////////////////////////////////////////////////////////////////////////////////
      #region Data Members

      // constants
      private static int SELECTED_COLOR_WIDTH = 40;
      private static int SELECTED_COLOR_HEIGHT = 40;
      private static int ARROW_BUTTON_WIDTH = System.Windows.Forms.SystemInformation.HorizontalScrollBarArrowWidth;
      private static int HUE_SELECT_ARROW_HEIGHT = 3;

      // Members
      int         m_ControlID;    // identifier for this control
      float       m_Hue;          // varies 0.0f - 360.0f (degrees)
      float       m_Luminance;    // varies 0.0f - 1.0f
      float       m_Saturation;   // varies 0.0f - 1.0f;
      float       m_LumMax;       // maximum scroll bar value
      float       m_SatMax;       // maximum scroll bar value
      float       m_HuePixelStep; // amount of hue per pixel

      IColorSelectCallback  m_cscHost;

      // UI Trackers
      Rectangle     m_rcSelColor;  // selected color region
      Rectangle     m_rcHueBar;    // bar where hue and arrows reside
      Timer         m_Timer;       // timer for holding down one of the arrow buttons
      MouseButtons  m_Button;      // which button engaged the timer
      bool          m_bHasFocus;

      // Windows
      private System.Windows.Forms.Label       lblBrightness;
      private System.Windows.Forms.Label       lblSaturation;
      private System.Windows.Forms.HScrollBar  wndScrollBrightness;
      private System.Windows.Forms.HScrollBar  wndScrollSaturation;
      private CustomUIControls.ArrowButton     btnLeft;
      private CustomUIControls.ArrowButton     btnRight;

      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      #endregion

      //////////////////////////////////////////////////////////////////////////////////////
      // Construction / Destruction
      //////////////////////////////////////////////////////////////////////////////////////
      #region Construction / Destruction

      /// <summary>
      /// Default constructor
      /// </summary>
      public ColorSelectControl()
      {
         // This call is required by the Windows.Forms Form Designer.
         InitializeComponent();

         m_ControlID = 0;
         m_Hue = 240.0f;
         m_Luminance = 0.5f;
         m_Saturation = 0.5f;
         m_Timer = new Timer();
         m_Timer.Tick += new EventHandler(Timer_Tick);
         m_Timer.Enabled = false;
         m_Timer.Interval = 100; // 10 clicks a second

         m_cscHost = null;
         m_bHasFocus = false;

         // fast double buffering for flicker-free drawing
         SetStyle(
            ControlStyles.AllPaintingInWmPaint | 
            ControlStyles.UserPaint | 
            ControlStyles.DoubleBuffer |
            ControlStyles.ResizeRedraw, true);
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
         this.wndScrollBrightness = new System.Windows.Forms.HScrollBar();
         this.wndScrollSaturation = new System.Windows.Forms.HScrollBar();
         this.lblBrightness = new System.Windows.Forms.Label();
         this.lblSaturation = new System.Windows.Forms.Label();
         this.btnLeft = new CustomUIControls.ArrowButton();
         this.btnRight = new CustomUIControls.ArrowButton();
         this.SuspendLayout();
         // 
         // wndScrollBrightness
         // 
         this.wndScrollBrightness.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.wndScrollBrightness.LargeChange = 100;
         this.wndScrollBrightness.Location = new System.Drawing.Point(64, 24);
         this.wndScrollBrightness.Maximum = 1099;
         this.wndScrollBrightness.Name = "wndScrollBrightness";
         this.wndScrollBrightness.Size = new System.Drawing.Size(126, 16);
         this.wndScrollBrightness.SmallChange = 5;
         this.wndScrollBrightness.TabIndex = 3;
         this.wndScrollBrightness.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnScrollBrightness);
         // 
         // wndScrollSaturation
         // 
         this.wndScrollSaturation.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.wndScrollSaturation.LargeChange = 100;
         this.wndScrollSaturation.Location = new System.Drawing.Point(254, 24);
         this.wndScrollSaturation.Maximum = 1099;
         this.wndScrollSaturation.Name = "wndScrollSaturation";
         this.wndScrollSaturation.Size = new System.Drawing.Size(120, 16);
         this.wndScrollSaturation.SmallChange = 5;
         this.wndScrollSaturation.TabIndex = 5;
         this.wndScrollSaturation.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnScrollSaturation);
         // 
         // lblBrightness
         // 
         this.lblBrightness.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.lblBrightness.Location = new System.Drawing.Point(2, 24);
         this.lblBrightness.Name = "lblBrightness";
         this.lblBrightness.Size = new System.Drawing.Size(62, 16);
         this.lblBrightness.TabIndex = 2;
         this.lblBrightness.Text = "Brightness:";
         this.lblBrightness.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // lblSaturation
         // 
         this.lblSaturation.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.lblSaturation.Location = new System.Drawing.Point(191, 24);
         this.lblSaturation.Name = "lblSaturation";
         this.lblSaturation.Size = new System.Drawing.Size(62, 16);
         this.lblSaturation.TabIndex = 4;
         this.lblSaturation.Text = "Saturation:";
         this.lblSaturation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // btnLeft
         // 
         this.btnLeft.Direction = CustomUIControls.ArrowButtonDirection.Left;
         this.btnLeft.Location = new System.Drawing.Point(0, 0);
         this.btnLeft.Name = "btnLeft";
         this.btnLeft.Size = new System.Drawing.Size(20, 22);
         this.btnLeft.TabIndex = 0;
         this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
         this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseButtonUp);
         this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnLeftButtonDown);
         // 
         // btnRight
         // 
         this.btnRight.Direction = CustomUIControls.ArrowButtonDirection.Right;
         this.btnRight.Location = new System.Drawing.Point(354, 0);
         this.btnRight.Name = "btnRight";
         this.btnRight.Size = new System.Drawing.Size(20, 22);
         this.btnRight.TabIndex = 1;
         this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
         this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseButtonUp);
         this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnRightButtonDown);
         // 
         // ColorSelectControl
         // 
         this.AccessibleDescription = "Select a color to use";
         this.AccessibleName = "Select Color";
         this.Controls.Add(this.btnLeft);
         this.Controls.Add(this.btnRight);
         this.Controls.Add(this.lblSaturation);
         this.Controls.Add(this.lblBrightness);
         this.Controls.Add(this.wndScrollSaturation);
         this.Controls.Add(this.wndScrollBrightness);
         this.Name = "ColorSelectControl";
         this.Size = new System.Drawing.Size(412, 40);
         this.Resize += new System.EventHandler(this.OnResize);
         this.Load += new System.EventHandler(this.OnFormLoad);
         this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
         this.ResumeLayout(false);

      }
      #endregion

      //////////////////////////////////////////////////////////////////////////////////////
      // Windows Event Handlers
      //////////////////////////////////////////////////////////////////////////////////////
      #region Windows Event Handlers

      /// <summary>
      /// The control is being initialized for the first time
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Event parameters</param>
      private void OnFormLoad(object sender, System.EventArgs e)
      {
         // see the MSDN article on the ScrollBar Maximum property for the reason behind this equation
         m_LumMax = (float) (wndScrollBrightness.Maximum - wndScrollBrightness.LargeChange + 1);
         if (m_LumMax <= 0.0f)
         {
            wndScrollBrightness.LargeChange = 10;
            wndScrollBrightness.Maximum = 109;
            wndScrollBrightness.Minimum = 1;
            m_LumMax = 100.0f;
         }
         // see the MSDN article on the ScrollBar Maximum property for the reason behind this equation
         m_SatMax = (float) (wndScrollSaturation.Maximum - wndScrollSaturation.LargeChange + 1);
         if (m_SatMax <= 0.0f)
         {
            wndScrollSaturation.LargeChange = 10;
            wndScrollSaturation.Maximum = 109;
            wndScrollSaturation.SmallChange = 1;
            m_SatMax = 100.0f;
         }
         wndScrollBrightness.Value = (int)(m_LumMax * m_Luminance + 0.5f);
         wndScrollSaturation.Value = (int)(m_SatMax * m_Saturation + 0.5f);
      } // OnFormLoad()


      /// <summary>
      /// Control is resizing. As it turns out, it's easier to code this manually than
      /// to fight with anchors, docking and adding Panel controls until it all works.
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Event parameters</param>
      private void OnResize(object sender, System.EventArgs e)
      {
         // first determine the minimum width
         int MinWidth = lblBrightness.Width;
         MinWidth += lblSaturation.Width;
         MinWidth += SELECTED_COLOR_WIDTH;
         int MinScrollBar = System.Windows.Forms.SystemInformation.HorizontalScrollBarArrowWidth * 2 +
            System.Windows.Forms.SystemInformation.HorizontalScrollBarThumbWidth;
         MinWidth += MinScrollBar * 2;

         Rectangle rcArea = this.ClientRectangle;
         int MinHeight = rcArea.Height;
         bool bChange = false;
         if (MinWidth > rcArea.Width)
         {
            bChange = true;
         }
         else
         {
            MinWidth = rcArea.Width;
         }
         if (MinHeight < SELECTED_COLOR_HEIGHT)
         {
            MinHeight = SELECTED_COLOR_HEIGHT;
            bChange = true;
         }

         if (bChange)
         {
            // at this point resizing will shrink over the control area because the control
            // cannot get any smaller
            rcArea = new Rectangle(
               this.ClientRectangle.Left,
               this.ClientRectangle.Top,
               MinWidth,
               MinHeight);
         }

         // next calculate the selected color area
         m_rcSelColor = new Rectangle(
            rcArea.Right - SELECTED_COLOR_WIDTH - 1,
            rcArea.Top,
            SELECTED_COLOR_WIDTH,
            rcArea.Height - 1);

         // calculate the height of the hue bar area, which is everything left over after
         // the bottom scroll bars are drawn, with a 1 pixel buffer
         int HueBarHeight = (rcArea.Bottom - rcArea.Top) - 
            System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight - 1;
         if (HueBarHeight < 0)
         {
            HueBarHeight = 20; // control is not going to fit...
         }

         // the left and right buttons. we shrink them a bit vertically so that the arrows
         // indicating the selected hue stand out a bit more
         btnLeft.SetBounds(
            rcArea.Left,
            rcArea.Top + HUE_SELECT_ARROW_HEIGHT,
            ARROW_BUTTON_WIDTH,
            HueBarHeight - (2*HUE_SELECT_ARROW_HEIGHT) + 1);

         btnRight.SetBounds(
            m_rcSelColor.Left - ARROW_BUTTON_WIDTH - 1,
            rcArea.Top + HUE_SELECT_ARROW_HEIGHT,
            ARROW_BUTTON_WIDTH,
            HueBarHeight - (2*HUE_SELECT_ARROW_HEIGHT) + 1);

         // and the hue bar area
         m_rcHueBar = new Rectangle(
            btnLeft.Right,
            rcArea.Top,
            (btnRight.Left - btnLeft.Right),
            HueBarHeight);

         // important calculation for matching a screen pixel to a hue amount
         m_HuePixelStep = 360.0f / ((float) m_rcHueBar.Width);

         // finally, position the controls
         int ScrollWidth = ((m_rcSelColor.Left - rcArea.Left) - lblBrightness.Width - lblSaturation.Width) / 2;
         if (ScrollWidth < MinScrollBar)
         {
            ScrollWidth = MinScrollBar;
         }
         int BottomHeight = rcArea.Bottom - m_rcHueBar.Bottom;
         lblBrightness.SetBounds(
            rcArea.Left, 
            m_rcHueBar.Bottom + 1,
            lblBrightness.Width, 
            BottomHeight, 
            BoundsSpecified.All);
         wndScrollBrightness.SetBounds(
            lblBrightness.Right,
            m_rcHueBar.Bottom + 1,
            ScrollWidth,
            BottomHeight,
            BoundsSpecified.All);
         lblSaturation.SetBounds(
            wndScrollBrightness.Right, 
            m_rcHueBar.Bottom + 1,
            lblSaturation.Width, 
            BottomHeight, 
            BoundsSpecified.All);
         wndScrollSaturation.SetBounds(
            lblSaturation.Right,
            m_rcHueBar.Bottom + 1,
            ScrollWidth,
            BottomHeight,
            BoundsSpecified.All);
      } // OnResize()


      /// <summary>
      /// Draw the control event
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Paint arguments</param>
      private void OnPaint(object sender, System.Windows.Forms.PaintEventArgs PaintingArgs)
      {
         Graphics g = PaintingArgs.Graphics;

         // fill in the background 
         SolidBrush brBack = new SolidBrush(this.BackColor);
         g.FillRectangle(brBack, this.ClientRectangle);

         // draw the hue bar
         int kk = 0;
         int NumShades = m_rcHueBar.Width;
         float Hue = 0.0f;
         float HueMinimumDiff = float.MaxValue;
         float HueAtMinimum = 0.0f;
         for (kk = 0; kk < NumShades; kk++)
         {
            // draw the hue shade
            Color clrShade = HSLToRGB(Hue, m_Saturation, m_Luminance);
            Pen penColor = new Pen(clrShade, 1.0f);
            g.DrawLine(penColor, 
               kk + m_rcHueBar.Left, 
               m_rcHueBar.Top + HUE_SELECT_ARROW_HEIGHT,
               kk + m_rcHueBar.Left, 
               m_rcHueBar.Bottom - HUE_SELECT_ARROW_HEIGHT);

            // are we closest to the selected value?
            float Diff = Math.Abs(m_Hue - Hue);
            if (Diff < HueMinimumDiff)
            {
               HueMinimumDiff = Diff;
               HueAtMinimum = Hue;
            }

            // go to the next Hue
            Hue += m_HuePixelStep;
         }

         // determine the X-offset of the currently selected hue
         int XOffset = 0;
         if (m_HuePixelStep > 0.0f)
         {
            XOffset = (int)(m_Hue / m_HuePixelStep);
         }

         // draw the arrows for the currently selected color
         AdjustableArrowCap myArrow = new AdjustableArrowCap(HUE_SELECT_ARROW_HEIGHT*2 - 1, 
            HUE_SELECT_ARROW_HEIGHT, true);

         Pen capPen = new Pen(Color.Black);
         capPen.CustomEndCap = myArrow;
         g.DrawLine(capPen, 
            m_rcHueBar.Left + XOffset, 
            m_rcHueBar.Top, 
            m_rcHueBar.Left + XOffset, 
            m_rcHueBar.Top + HUE_SELECT_ARROW_HEIGHT + 1);

         g.DrawLine(capPen, 
            m_rcHueBar.Left + XOffset, 
            m_rcHueBar.Bottom, 
            m_rcHueBar.Left + XOffset, 
            m_rcHueBar.Bottom - (HUE_SELECT_ARROW_HEIGHT + 1));

         // Draw the selected color area
         Color clrSelected = HSLToRGB(m_Hue, m_Saturation, m_Luminance);
         SolidBrush brSelected = new SolidBrush(clrSelected);
         g.FillRectangle(brSelected, m_rcSelColor);

         // draw the frame around the selected color
         g.DrawRectangle(System.Drawing.SystemPens.ControlText, m_rcSelColor);
         if (m_bHasFocus && this.ContainsFocus && this.ShowFocusCues)
         {
            Rectangle rcTemp = m_rcSelColor;
            rcTemp.Inflate(-1, -1);
            g.DrawRectangle(System.Drawing.SystemPens.ControlText, rcTemp);
         }
      } // OnPaint()


      /// <summary>
      /// User is moving the the scroll control for brightness/luminance
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Event arguments</param>
      private void OnScrollBrightness(object sender, System.Windows.Forms.ScrollEventArgs e)
      {
         m_Luminance = e.NewValue / m_LumMax;
         ColorChanged();
      } // OnScrollBrightness()


      /// <summary>
      /// User is moving the scroll control for saturation
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Event arguments</param>
      private void OnScrollSaturation(object sender, System.Windows.Forms.ScrollEventArgs e)
      {
         m_Saturation = e.NewValue / m_SatMax;
         ColorChanged();
      } // OnScrollSaturation()


      /// <summary>
      /// User is clicking (once) the button to move the hue to the left. This is also called
      /// when the user presses the left arrow when this control has keyboard focus.
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Event arguments</param>
      private void btnLeft_Click(object sender, System.EventArgs e)
      {
         // move hue left (towards zero)
         if (m_Hue > m_HuePixelStep)
         {
            m_Hue -= m_HuePixelStep;
            ColorChanged();
         }
      } // btnLeft_Click()

      /// <summary>
      /// User is clicking (once) the button to move the hue to the right. This is also called
      /// when the user presses the right arrow when this control has keyboard focus.
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Event arguments</param>
      private void btnRight_Click(object sender, System.EventArgs e)
      {
         // move hue right (towards 360.0)
         if (m_Hue < (360.0f - m_HuePixelStep))
         {
            m_Hue += m_HuePixelStep;
            ColorChanged();
         }
      } // btnRight_Click()


      /// <summary>
      /// User is pressing a dialog key while the control has keyboard focus. Check for arrow keys and
      /// allow hue select if the arrow keys are used.
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Event arguments</param>
      /// <returns>True </returns>
      protected override bool ProcessDialogKey(Keys keyData)
      {
         // override default behavior of left and right arrow keys
         if (keyData == Keys.Left)
         {
            btnLeft_Click(null, new EventArgs());
            return true;
         }
         if (keyData == Keys.Right)
         {
            btnRight_Click(null, new EventArgs());
            return true;
         }

         // do the default
         return base.ProcessDialogKey (keyData);
      } // ProcessDialogKey()


      /// <summary>
      /// Focus is entering this control or one of its children
      /// </summary>
      /// <param name="e">Event arguments</param>
      protected override void OnEnter(EventArgs e)
      {
         base.OnEnter (e);
         m_bHasFocus = true; // setup for drawing focus cue
         this.Refresh();
      } // OnEnter()


      /// <summary>
      /// Focus is leaving this control
      /// </summary>
      /// <param name="e">Event arguments</param>
      protected override void OnLeave(EventArgs e)
      {
         base.OnLeave (e);
         m_bHasFocus = false; // shouldn't draw focus cues anymore
         this.Refresh();
      } // OnLeave()


      /// <summary>
      /// User is holding down the arrow left button to scroll left. This is different from a 
      /// single click, so we start a timer to perform multiple "clicks" while the timer
      /// is running, which allows the user to move the hue continuously left.
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Event arguments</param>
      private void OnLeftButtonDown(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         m_Timer.Enabled = true;
         // now we aren't really talking about the 'left mouse button', we're talking about
         // the 'left arrow button', but the enumeration still makes sense.
         m_Button = MouseButtons.Left;
         m_Timer.Start();
      } // OnLeftButtonDown()


      /// <summary>
      /// User is holding down the arrow left button to scroll right. This is different from a 
      /// single click, so we start a timer to perform multiple "clicks" while the timer
      /// is running, which allows the user to move the hue continuously right.
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Event arguments</param>
      private void OnRightButtonDown(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         m_Timer.Enabled = true;
         // now we are't really talking about the 'right mouse button', we're talking about
         // the 'right arrow button', but the enumeration still makes sense.
         m_Button = MouseButtons.Right;
         m_Timer.Start();
      } // OnRightButtonDown()


      /// <summary>
      /// Timer has fired while the user is holding down the left mouse button over either the
      /// arrow left or the arrow right buttons.
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Event arguments</param>
      private void Timer_Tick(object sender, EventArgs e)
      {
         // fire a click event
         if (m_Button == MouseButtons.Left)
         {
            btnLeft_Click(sender, e);
         }
         else if (m_Button == MouseButtons.Right)
         {
            btnRight_Click(sender, e);
         }
      } // Timer_Tick()


      /// <summary>
      /// User has let go of the left mouse button after holding down either the arrow
      /// left or the arrow right button. Stop the timer.
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Event arguments</param>
      private void OnMouseButtonUp(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         m_Timer.Stop();
         m_Timer.Enabled = false;
      } // OnMouseButtonUp()


      /// <summary>
      /// User has released the left mouse button, check if they just clicked on the hue
      /// bar or the selected color region.
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Event arguments</param>
      private void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if (m_rcHueBar.Contains(e.X, e.Y))
         {
            m_Hue = (float) (e.X - m_rcHueBar.Left) * m_HuePixelStep;
            ColorChanged();
            return;
         }
         if (m_rcSelColor.Contains(e.X, e.Y))
         {
            // show the more cumbersome but very precise color selection dialog
            ColorDialog dlgColor = new ColorDialog();
            dlgColor.FullOpen = true;
            dlgColor.Color = HSLToRGB(m_Hue, m_Saturation, m_Luminance);
            DialogResult result = dlgColor.ShowDialog(this);
            if (result == DialogResult.OK)
            {
               RGBToHSL(dlgColor.Color, ref m_Hue, ref m_Saturation, ref m_Luminance);

               // update the scroll bars
               wndScrollBrightness.Value = (int)(m_LumMax * m_Luminance + 0.5f);
               wndScrollSaturation.Value = (int)(m_SatMax * m_Saturation + 0.5f);

               // update the dialog
               ColorChanged();
               return;
            }
         } // if in selected color region
      } // OnMouseUp()

      #endregion

      //////////////////////////////////////////////////////////////////////////////////////
      // Private Methods
      //////////////////////////////////////////////////////////////////////////////////////
      #region Private Methods

      /// <summary>
      /// The color has been modified, notify the callback host if any
      /// </summary>
      private void ColorChanged()
      {
         this.Refresh();
         if (m_cscHost != null)
         {
            Color clrNewColor = HSLToRGB(m_Hue, m_Saturation, m_Luminance);
            m_cscHost.ColorChanged(m_ControlID, clrNewColor);
         }
      } // ColorChanged()

      /// <summary>
      /// Convert RGB color to Hue, Saturation, Luminance. Adapted from C++ code for CColor
      /// obtained from CColor - RGB and HLS combined in one class By Christian Rodemeyer 
      /// at http://codeproject.com/bitmap/ccolor.asp
      /// </summary>
      /// <param name="inColor">Color in</param>
      /// <param name="Hue">Hue 0-360</param>
      /// <param name="Saturation">Saturation (0.0 - 1.0)</param>
      /// <param name="Luminance">Luminance (0.0 - 1.0)</param>
      void RGBToHSL(Color inColor, ref float Hue, ref float Saturation, ref float Luminance)
      {
         float Red = (float) inColor.R;
         float Green = (float) inColor.G;
         float Blue = (float) inColor.B;
         float minval = Red;
         if (Green < minval) minval = Green;
         if (Blue < minval) minval = Blue;
         float maxval = Red;
         if (Green > maxval) maxval = Green;
         if (Blue > maxval) maxval = Blue;

         float mdiff  = maxval - minval;
         float msum   = maxval + minval;

         Luminance = msum / 510.0f;
         Saturation = 0.0f;
         Hue = 0.0f;

         if (maxval == minval) 
         {
            Saturation = 0.0f;
            Hue = 0.0f; 
         }   
         else 
         { 
            float rnorm = (maxval - Red  ) / mdiff;      
            float gnorm = (maxval - Green) / mdiff;
            float bnorm = (maxval - Blue ) / mdiff;   

            if (Luminance <= 0.5f)
            {
               Saturation =  (mdiff / msum);
            }
            else
            {
               Saturation = (mdiff / (510.0f - msum));
            }

            if (Red   == maxval) Hue = 60.0f * (6.0f + bnorm - gnorm);
            if (Green == maxval) Hue = 60.0f * (2.0f + rnorm - bnorm);
            if (Blue  == maxval) Hue = 60.0f * (4.0f + gnorm - rnorm);
            if (Hue > 360.0f) Hue = Hue - 360.0f;
         }
      } // RGBToHSL()

      /// <summary>
      /// Helper method to do some math to convert HSL/HLS to RGB. Adapted from C++ code for CColor
      /// obtained from CColor - RGB and HLS combined in one class By Christian Rodemeyer 
      /// at http://codeproject.com/bitmap/ccolor.asp
      /// </summary>
      /// <param name="rm1">Root mean 1</param>
      /// <param name="rm2">Root mean 2</param>
      /// <param name="rh">Right hand side</param>
      /// <returns>Byte containing part of a RGB value</returns>
      private byte ToRGB1(float rm1, float rm2, float rh)
      {
         if (rh > 360.0f) 
         {
            rh -= 360.0f;
         }
         else if (rh <   0.0f) 
         {
            rh += 360.0f;
         }

         if (rh <  60.0f) 
         {
            rm1 = rm1 + (rm2 - rm1) * rh / 60.0f;   
         }
         else if (rh < 180.0f) 
         {
            rm1 = rm2;
         }
         else if (rh < 240.0f) 
         {
            rm1 = rm1 + (rm2 - rm1) * (240.0f - rh) / 60.0f;      
         }

         return (byte)(rm1 * 255);
      } // ToRGB1()


      /// <summary>
      /// Convert HSL to RGB (.NET Color class). Adapted from C++ code for CColor
      /// obtained from CColor - RGB and HLS combined in one class By Christian Rodemeyer 
      /// at http://codeproject.com/bitmap/ccolor.asp
      /// </summary>
      /// <param name="Hue">Hue in degrees 0.0f - 360.0f</param>
      /// <param name="Saturation">Saturation from 0.0f - 1.0f</param>
      /// <param name="Luminance">Luminance/Brightness from 0.0f - 1.0f</param>
      /// <returns>Color class initialized to the selected color.</returns>
      private Color HSLToRGB(float Hue, float Saturation, float Luminance) 
      {
         int Red = (int) (Luminance * 255.0f);
         int Green = (int) (Luminance * 255.0f);
         int Blue = (int) (Luminance * 255.0f);
         if (Saturation != 0.0)
         {
            float rm1, rm2;
		        
            if (Luminance <= 0.5f) 
            {
               rm2 = Luminance + Luminance * Saturation;  
            }
            else
            {
               rm2 = Luminance + Saturation - Luminance * Saturation;
            }
            rm1 = 2.0f * Luminance - rm2; 
            Red  = ToRGB1(rm1, rm2, Hue + 120.0f);   
            Green = ToRGB1(rm1, rm2, Hue);
            Blue = ToRGB1(rm1, rm2, Hue - 120.0f);
         }

         return Color.FromArgb(Red, Green, Blue);
      } // HSLToRGB()

      #endregion

      //////////////////////////////////////////////////////////////////////////////////////
      // Public Properties
      //////////////////////////////////////////////////////////////////////////////////////
      #region Public Properties

      /// <summary>
      /// A unique identifier for this control, set by the host control/dialog/form. This
      /// identifier is sent over the IColorSelectCallback interface so that the host knows
      /// which color select control changed, if there are multiple color select controls on
      /// a dialog
      /// </summary>
      public int ControlID
      {
         get
         {
            return m_ControlID;
         }
         set
         {
            m_ControlID = value;
         }
      } // property ControlID


      /// <summary>
      /// An object to receive a callback when the color changes
      /// </summary>
      public IColorSelectCallback CallbackHost
      {
         set
         {
            m_cscHost = value;
         }
      } // property CallBackHost


      /// <summary>
      /// Gets or sets the selected color. You might set it prior to showing the control
      /// so that the control is initialized using a default or previously stored color.
      /// </summary>
      public Color SelectedColor
      {
         get
         {
            return HSLToRGB(m_Hue, m_Saturation, m_Luminance);
         }
         set
         {
            RGBToHSL(value, ref m_Hue, ref m_Saturation, ref m_Luminance);
            // update scroll bar positions
            wndScrollBrightness.Value = (int)(m_LumMax * m_Luminance + 0.5f);
            wndScrollSaturation.Value = (int)(m_SatMax * m_Saturation + 0.5f);
         }
      } // property SelectedColor

      #endregion

   } // class ColorSelectControl

   /// <summary>
   /// Interface to let the host control know when a color has changed
   /// </summary>
   public interface IColorSelectCallback
   {
      /// <summary>
      /// The user has selected a new color
      /// </summary>
      /// <param name="ControlID">The identifier for the color selection control</param>
      /// <param name="clrNewColor">The new color selected in the color selection control</param>
      void ColorChanged(int ControlID, System.Drawing.Color clrNewColor);
   } // interface IColorSelectCallback
} // namespace CustomUIControls
