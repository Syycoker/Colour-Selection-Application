using ColorSelectDemo;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColourSelectionApplication
{
  public partial class ColourForm : Form
  {
    #region Constructor
    public ColourForm()
    {
      InitializeComponent();

      ColourManager.UserHasSetColour += HandleUserHasRightClickedPanel;

      // Set the present colours
      preset1.BackColor = ColourManager.PresetColours[1];
      preset2.BackColor = ColourManager.PresetColours[2];
      preset3.BackColor = ColourManager.PresetColours[3];
      preset4.BackColor = ColourManager.PresetColours[4];
      preset5.BackColor = ColourManager.PresetColours[5];
      preset6.BackColor = ColourManager.PresetColours[6];
      preset7.BackColor = ColourManager.PresetColours[7];
      preset8.BackColor = ColourManager.PresetColours[8];
      preset9.BackColor = ColourManager.PresetColours[9];
    }
    #endregion
    #region Private
    /// <summary>
    /// Sets the grid control in the main panel.
    /// </summary>
    /// <param name="grid"></param>
    private void SetGridControl(GridPanel grid)
    {
      MainPanel.Controls.Clear();

      MainPanel.Controls.Add(grid);

      grid.Dock = DockStyle.Fill;
    }
    #endregion
    #region Events
    /// <summary>
    /// Loads a grid from file.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleLoadGrid(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog()
      { 
        Filter = $"{ ColourManager.FILE_EXTENSION_NAME} | *{ ColourManager.FILE_EXTENSION }"
      };

      var openResponse = openFileDialog.ShowDialog();
      string filePath = openFileDialog.FileName;

      if (openResponse != DialogResult.OK || string.IsNullOrEmpty(filePath)) return;

      GridPanel grid = ColourManager.LoadGrid(filePath);
      SetGridControl(grid);
    }

    /// <summary>
    /// Creates a default grid.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleCreateGrid(object sender, EventArgs e)
    {
      try
      {
        int x = 0;
        int y = 0;

        var validWidth = int.TryParse(WidthTextBox.Text, out x);
        var validHeight = int.TryParse(HeightTextBox.Text, out y);

        // Sanity check
        if (x == 0 || !validWidth) throw new Exception("Width is incorrect.");
        if (y == 0 || !validHeight) throw new Exception("Height is incorrect.");

        GridPanel grid = ColourManager.CreateDefaultGrid(x, y);
        SetGridControl(grid);
      }
      catch(Exception _)
      {
        MessageBox.Show(_.Message,"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }

    /// <summary>
    /// Saves the current grid in the colour manager to file, provided a suitable name
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleSaveGrid(object sender, EventArgs e)
    {
      // Make sure the user has set a value in the textBox.
      var sanityCheck = string.IsNullOrEmpty(SaveTextBox.Text);

      if (sanityCheck)
      {
        MessageBox.Show("Please set a name in the textbox.", "Warning",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);

        return;
      }

      var response = MessageBox.Show("Save document?", "Confirmation",
        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

      if (response != DialogResult.Yes) return;

      string text = ColourManager.SelectedName;
      int underscoreIndex = text.LastIndexOf("_");
      string strippedTextName = string.Empty;

      if (underscoreIndex != -1)
        strippedTextName = text.Subsequence(0, underscoreIndex);
      else
        strippedTextName = text;

      string fileName = $"{ strippedTextName }_{ ColourManager.Grid?.X_DIMENSION }x{ ColourManager.Grid.Y_DIMENSION }";

      SaveFileDialog saveFileDialog = new SaveFileDialog()
      {
        Filter = $"{ ColourManager.FILE_EXTENSION_NAME} | *{ ColourManager.FILE_EXTENSION }",
        FileName = fileName
      };

      var saveResponse = saveFileDialog.ShowDialog();
      string filePath = saveFileDialog.FileName;

      if (saveResponse != DialogResult.OK || string.IsNullOrEmpty(filePath)) return;

      // Save the grid
      ColourManager.SaveGrid(filePath);
    }

    /// <summary>
    /// Whenever the colour has been selected, send the colour via delegate to all the listeners.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleColourSelected(object sender, MouseEventArgs e)
    {
      if(e.Button == MouseButtons.Left)
        ColourManager.SetColour(colorSelectControl1.SelectedColor);
    }

    /// <summary>
    /// Whenever the colour has been selected, send the colour via delegate to all the listeners.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleColourControlLoaded(object sender, EventArgs e)
    {
      colorSelectControl1.SelectedColor = Color.FromArgb(129, 0 , 234);
      ColourManager.SetColour(colorSelectControl1.SelectedColor);
    }

    /// <summary>
    /// Sends the name to the colour manager and all of it's listeners.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleNameChanged(object sender, EventArgs e)
    {
      ColourManager.UserHasSetName?.Invoke(SaveTextBox.Text);
    }

    /// <summary>
    /// Removes reference to the grid.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleReset(object sender, EventArgs e)
    {
      ColourManager.Reset();
      MainPanel.Controls.Clear();
    }

    /// <summary>
    /// Resets all the colours back to the default colour.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleClear(object sender, EventArgs e)
    {
      ColourManager.ClearGrid();
    }

    /// <summary>
    /// Closes the form.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleClose(object sender, EventArgs e)
    {
      Close();
    }

    /// <summary>
    /// Whenever the user has rsight clicked a panel, set the selected colour to that colour.
    /// </summary>
    /// <param name="colour"></param>
    private void HandleUserHasRightClickedPanel(Color colour)
    {
      colorSelectControl1.SelectedColor = ColourManager.SelectedColour;
      colorSelectControl1.Refresh();
    }

    /// <summary>
    /// What happnes when a user left clicks or right clicks a preset panel.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandlePresetClicked(object sender, MouseEventArgs e)
    {
      Panel panel = (sender as Panel);
      string name = panel.Name;
      int presetIndex = int.Parse(name.Subsequence(name.LastIndexOf("t") + 1, name.Length));

      switch (e.Button)
      {
        case MouseButtons.Left:
          // User wants to use the panel's colour
          ColourManager.SetColour(panel.BackColor);
          break;

        case MouseButtons.Right:
          // User wants to change the preset colour to the colour already selected.
          ColourManager.UserHasSetPresetColour?.Invoke(presetIndex, ColourManager.SelectedColour);
          panel.BackColor = ColourManager.SelectedColour;
          break;
      }
    }

    /// <summary>
    /// When the form is closing, prompt?
    /// </summary>
    /// <param name="e"></param>
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      base.OnFormClosing(e);

      if (!ColourManager.Preset_Changed) return;

      DialogResult response = MessageBox.Show("Changes have been made to the present colours, save?",
        "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

      if (response != DialogResult.Yes) return;

      // Save the colours back to file.
      ColourManager.SavePresetColoursToFile(ColourManager.PresetColours);
    }

    /// <summary>
    /// Roatest the grid in the Colour Manager by 90 degrees to the right.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleGridRotate(object sender, EventArgs e)
    {
      ColourManager.RotateGrid();
    }

    /// <summary>
    /// Undoes the previous action done to the board.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleUndo(object sender, EventArgs e)
    {
      ColourManager.Grid?.Undo();
    }
    #endregion
  }
}
