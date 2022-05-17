using ColourSelectionApplication;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ColorSelectDemo
{
  public class GridPanel : Panel
  {
    #region Constants
    const int CHILD_PANEL_WIDTH = 30;
    const int CHILD_PANEL_HEIGHT = 30;
    const int CHILD_PANEL_SPACING = 3;
    const bool SCROLL_ENABLED = true;
    #endregion
    #region Members
    /// <summary>
    /// A grid of colours to represent the led's on the panel.
    /// </summary>
    public readonly Panel[,] Grid;

    /// <summary>
    /// The x dimension of the grid.
    /// </summary>
    public readonly int X_DIMENSION;

    /// <summary>
    /// The y dimension of the grid.
    /// </summary>
    public readonly int Y_DIMENSION;

    /// <summary>
    /// The size of the child panels.
    /// </summary>
    public Size Child_Panel_Size { get; private set; } = new Size(CHILD_PANEL_WIDTH, CHILD_PANEL_HEIGHT);

    /// <summary>
    /// Used to undo/redo actions done upon the colour grid.
    /// </summary>
    private Stack<Color[,]> History { get; set; } = new();
    #endregion
    #region Constructor
    /// <summary>
    /// Standard constructor for the grid.
    /// </summary>
    /// <param name="row">How many rows will the grid be representing?</param>
    /// <param name="column">How many columns will the grid be representing?</param>
    public GridPanel(int row = 8, int column = 8, Color[,] colours = null)
    {
      try
      {
        // Set the dimensions
        X_DIMENSION = row;
        Y_DIMENSION = column;

        // Set the default colours
        if(colours is null)
        {
          colours = new Color[X_DIMENSION, Y_DIMENSION];

          for (int i = 0; i < X_DIMENSION; i++)
          {
            for (int j = 0; j < Y_DIMENSION; j++)
            {
              colours[i, j] = Color.Black;
            }
          }
        }

        // Set the main panel (parent).
        SetMainPanel();

        Grid = SetGrid(X_DIMENSION, Y_DIMENSION, colours);
      }
      catch(Exception e)
      {
        MessageBox.Show(e.Message, "Construction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>
    /// Sets the grid.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="colours"></param>
    public Panel[,] SetGrid(int x, int y, Color[,] colours)
    {
      // Set the grid to an 8x8 grid by default.
      Panel[,] grid = new Panel[X_DIMENSION, Y_DIMENSION];

      // Set the panels for the grid.
      SetPanels(grid, X_DIMENSION, Y_DIMENSION, colours);

      return grid;
    }

    /// <summary>
    /// Sets a grid to the colours given.
    /// </summary>
    /// <param name="colours"></param>
    public void SetGridColours(Color[,] colours)
    {
      for (int y = 0; y < Y_DIMENSION; y++)
      {
        for (int x = 0; x < X_DIMENSION; x++)
        {
          Grid[x, y].BackColor = colours[x, y];
        }
      }
    }
    #endregion
    #region Public
    /// <summary>
    /// Returns a panel from a coordinate.
    /// </summary>
    /// <param name="x">The 'x' coordinate.</param>
    /// <param name="y">The 'y' coordinate.</param>
    /// <returns></returns>
    public Panel GetPanel(int x, int y)
    {
      // Check if the user is requesting to store a valid position in the grid.
      if (x > Grid.GetLength(0)) throw new Exception($"The '{ nameof(x) }' is out of bounds by '{ Grid.GetLength(0) - x }'.");
      if (y > Grid.GetLength(1)) throw new Exception($"The '{ nameof(y) }' is out of bounds by '{ Grid.GetLength(1) - y }'.");

      // return the panel.
      return Grid[x, y];
    }

    /// <summary>
    /// Sets a particular section of the grid to be of a colour.
    /// </summary>
    /// <param name="x">The 'x' coordinate in the grid representation.</param>
    /// <param name="y">The 'y' coordinate in the grid representation.</param>
    /// <param name="colour">The 'colour' to be placed in the grid.</param>
    public void SetPanel(int x, int y, Color colour)
    {
      // Set the position of the grid to be the colour they requested.
      Panel panel = GetPanel(x, y);
      panel.BackColor = colour;
    }
    #endregion
    #region Events
    /// <summary>
    /// Change the colour of the panel when the user clicks on it.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void HandleMouseClick(object sender, EventArgs args) => PaintPanel(ColourManager.SelectedColour);

    /// <summary>
    /// Change the colour of the panel when the user holds the mouse down.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void HandleMouseDown(object sender, MouseEventArgs args)
    {
      if (args.Button == MouseButtons.Left)
        PaintPanel(ColourManager.SelectedColour);
      else
        ColourManager.SetColour(GetPanelFromCursorPosition(Cursor.Position).BackColor);
    }
    
    /// <summary>
    /// Change the colour of the panel when the user holds & moves the mouse.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void HandleMouseMove(object sender, MouseEventArgs args)
    {
      if (args.Button == MouseButtons.Left)
        PaintPanel(ColourManager.SelectedColour);
    }
    #endregion
    #region Private
    /// <summary>
    /// Sets the main panel's attributes such as colour, size, etc.
    /// </summary>
    private void SetMainPanel()
    {
      // Setting the dimensions to the Parent panel
      int parent_Panel_Width = (X_DIMENSION * CHILD_PANEL_WIDTH) + 
        (CHILD_PANEL_SPACING * X_DIMENSION) + CHILD_PANEL_SPACING;

      int parent_Panel_Height = (Y_DIMENSION * CHILD_PANEL_HEIGHT) + 
        (CHILD_PANEL_SPACING * Y_DIMENSION) + CHILD_PANEL_SPACING;

      // The colour of the background
      Color parent_Panel_Backcolour = Color.White;

      // Set the size of the Panel
      Size size = new Size(parent_Panel_Width, parent_Panel_Height);
      Size = size;
      MaximumSize = size;
      MinimumSize = size;

      // Set the background colour
      BackColor = parent_Panel_Backcolour;

      // Is the control scrollable if the grid becomes too big?
      AutoScroll = SCROLL_ENABLED;
    }

    /// <summary>
    /// Generates panels to add to the main panel.
    /// </summary>
    /// <param name="row">The amount of panels to occupy the x-dimension.</param>
    /// <param name="col">The amount of panels to occupy the y-dimension.</param>
    private void SetPanels(Panel[,] grid, int rows, int columns, Color[,] colours)
    {
      // Generate and draw the panels.
      for (int x = 0; x < rows; x++)
      {
        for (int y = 0; y < columns; y++)
        {
          int xLocation = x * (Child_Panel_Size.Width + CHILD_PANEL_SPACING);
          int yLocation = y * ((Child_Panel_Size.Height + CHILD_PANEL_SPACING));

          // Create the child panel and fill in the attributes.
          Panel childPanel = new Panel()
          {
            Size = Child_Panel_Size,
            BackColor = colours[x, y],
            Location = new Point(xLocation + CHILD_PANEL_SPACING, yLocation + CHILD_PANEL_SPACING),
            Cursor = Cursors.Hand,
          };

          // Hand over the event args
          childPanel.Click += HandleMouseClick;
          childPanel.MouseDown += HandleMouseDown;
          childPanel.MouseMove += HandleMouseMove;

          // Set the panel in the matrix.
          grid[x, y] = childPanel;

          // Add the child control to the parent control.
          Controls.Add(childPanel);
        }
      }
    }

    /// <summary>
    /// Returns a child panel from a cursor position.
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    private Panel GetPanelFromCursorPosition(Point point)
    {
      // Get a control where the mouse currently is
      Point newPoint = PointToClient(point);
      Control control = GetChildAtPoint(newPoint);
      return (Panel)control;
    }

    /// <summary>
    /// Paint the control a colour where the mouse is.
    /// </summary>
    /// <param name="colour">The colour to change the panel to.</param>
    private void PaintPanel(Color colour)
    {
      // Get a control where the mouse currently is
      Panel panel = GetPanelFromCursorPosition(Cursor.Position);

      // If there is no control, just return
      if (panel is null) return;

      // Add the current state of the panel before the change.
      AddToHistory();

      // If there is a control, let's make sure it's a child control/panel.
      panel.BackColor = colour;
    }

    /// <summary>
    /// Gets the colours of a grid.
    /// </summary>
    /// <param name="gridPanel"></param>
    /// <returns></returns>
    public Color[,] GetGridColours()
    {
      Panel[,] gridPanel = Grid;

      int row = gridPanel.GetLength(0);
      int col = gridPanel.GetLength(1);

      Color[,] panel = new Color[row, col];


      for (int y = 0; y < col; y++)
      {
        for (int x = 0; x < row; x++)
        {
          panel[x, y] = gridPanel[x, y].BackColor;
        }
      }

      return panel;
    }

    /// <summary>
    /// Adds the action to the history.
    /// </summary>
    /// <param name="panel"></param>
    /// <param name="colour"></param>
    public void AddToHistory()
    {
      // Get the current state of the grid.
      var colours = GetGridColours();

      Color[,] previousGridLayout;

      if (History.Count < 1)
        previousGridLayout = new Color[1, 1];
      else
        previousGridLayout = History?.Peek();

      // If the current layout is the same as the previous one, return.
      if (Equals(colours, previousGridLayout)) return;

      History.Push(colours);
    }

    /// <summary>
    /// Use the latest colour added to the history.
    /// </summary>
    public void Undo()
    {
      // If there's nothing just return.
      if (History.Count < 1) return;

      // Get the previous colours and apply them to the grid.
      var colours = History.Pop();

      // Now use the colours.
      SetGridColours(colours);
    }

    /// <summary>
    /// Checks whether the colour schemes are the same or not.
    /// </summary>
    /// <param name="fromColour"></param>
    /// <param name="toColour"></param>
    /// <returns></returns>
    public bool Equals(Color[,] fromColour, Color[,] toColour)
    {
      if (fromColour.GetLength(0) != toColour.GetLength(0) ||
        fromColour.GetLength(1) != toColour.GetLength(1)) return false;

      int x = fromColour.GetLength(0);
      int y = fromColour.GetLength(1);

      for (int i = 0; i < x; i++)
      {
        for (int j = 0; j < y; j++)
        {
          if (fromColour[i, j] != toColour[i, j]) 
          {
            return false;
          }
        }
      }

      return true;
    }

    /// <summary>
    /// Resets all the panel colours.
    /// </summary>
    public void Clear()
    {
      foreach (Panel panel in Grid)
      {
        panel.BackColor = Color.Black;
      }

      // Reset the history
      History.Clear();
    }
    #endregion
  }
}
