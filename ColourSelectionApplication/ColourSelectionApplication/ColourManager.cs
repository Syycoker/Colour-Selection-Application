using ColorSelectDemo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ColourSelectionApplication
{
  /// <summary>
  /// Static class to manage all resources for the project, i.e. events.
  /// </summary>
  public static class ColourManager
  {
    #region Constants
    /// <summary>
    /// The file extension for the .c file.
    /// </summary>
    public const string FILE_EXTENSION = ".c";

    /// <summary>
    /// The name of the file extension.
    /// </summary>
    public const string FILE_EXTENSION_NAME = "C Source";

    /// <summary>
    /// The file extension for the 'presetcolours' file.
    /// </summary>
    public const string PRESET_EXTENSION = ".json";

    /// <summary>
    /// The name of the directory for the .c colour files.
    /// </summary>
    public const string PRESET_COLOURS_FILE_NAME = "presetcolours";
    #endregion
    #region Delegates / Callbacks
    /// <summary>
    /// The event that notifies all listeners what the currently selected colour is.
    /// </summary>
    public static ColourSetCallback UserHasSetColour = delegate { };

    /// <summary>
    /// The event that notifies all the listeners what the constant array will be called.
    /// </summary>
    public static VariableNameSetCallback UserHasSetName = delegate { };

    /// <summary>
    /// The event that notifies all listeners that a preset colour has been changed.
    /// </summary>
    public static PresetColourSetCallback UserHasSetPresetColour = delegate { };

    /// <summary>
    /// The event that nottifies all listeners whether the grid is too big.
    /// </summary>
    public static ReshapeChildPanelsCallback DoesGridExceedViewableSpace = delegate { };

    /// <summary>
    /// Sets the colour.
    /// </summary>
    /// <param name="colour"></param>
    public static void HandleColour(Color colour) => SelectedColour = colour;

    /// <summary>
    /// Sets the name.
    /// </summary>
    /// <param name="variableName"></param>
    public static void HandleName(string variableName) => SelectedName = variableName;

    /// <summary>
    /// Sets the preset colour.
    /// </summary>
    /// <param name="presetIndex"></param>
    /// <param name="colour"></param>
    private static void HandlePreset(int presetIndex, Color colour)
    {
      PresetColours[presetIndex] = colour;
      Preset_Changed = true;
    }

    /// <summary>
    /// Changes the size of the child panels in the grid if they're too big.
    /// </summary>
    /// <param name="mainPanelSize"></param>
    /// <param name="panelSize"></param>
    private static void HandleIsGridIsTooBig(Size mainPanelSize, Size panelSize)
    {
      // Calculate how big each child panel must be to now fit into 'mainPanelSize'.
      if (Grid is null) return; // If there is no grid, (which shouldn't be the case), move on.

      int xDifference = panelSize.Width - mainPanelSize.Width;
      int yDifference = panelSize.Height - mainPanelSize.Height;

      if (xDifference < 0 && yDifference < 0) return; // main panel is bigger.

      int childPanelWidth = (xDifference / Grid.X_DIMENSION) - Grid.Child_Panel_Size.Width;
      int childPanelHeight = (yDifference / Grid.Y_DIMENSION) - Grid.Child_Panel_Size.Height;

      Size newChildPanelSize = new Size(childPanelWidth, childPanelHeight);

      foreach (var childPanel in Grid.Grid)
      {
        // Change the child panel sizes
        childPanel.Size = newChildPanelSize;
      }
    }
    #endregion
    #region Constructor
    /// <summary>
    /// Static constructor to make sure all the file dependecnies and event handlers have been set.
    /// </summary>
    static ColourManager()
    {
      // Assign the event handlers
      UserHasSetColour += HandleColour;
      UserHasSetName += HandleName;
      UserHasSetPresetColour += HandlePreset;
      DoesGridExceedViewableSpace += HandleIsGridIsTooBig;

      // Make sure the project directory has a file called 'presetcolors.json'.
      Preset_Path = Directory_Path + "\\" + PRESET_COLOURS_FILE_NAME + PRESET_EXTENSION;

      // Make sure the file exists, if not, create it.
      if (!File.Exists(Preset_Path))
      {
        var stream = File.Create(Preset_Path);
        stream.Close(); // must close stream
      }

      // Load the preset colours from file.
      LoadPresetColoursFromFile(Preset_Path);
    }
    #endregion
    #region Members
    /// <summary>
    /// The currently open grid, could be null.
    /// </summary>
    public static GridPanel Grid { get; private set; }

    /// <summary>
    /// The colour the user has chosen.
    /// </summary>
    public static Color SelectedColour { get; private set; }

    /// <summary>
    /// The name the user has chosen to be the file name and the constant name.
    /// </summary>
    public static string SelectedName { get; private set; }

    /// <summary>
    /// The path of the directory.
    /// </summary>
    public static string Directory_Path { get; private set; } = Directory.GetCurrentDirectory();

    /// <summary>
    /// The path of the presetcolours.json file.
    /// </summary>
    public static string Preset_Path { get; private set; } = string.Empty;

    /// <summary>
    /// Have the preset colours changed?
    /// </summary>
    public static bool Preset_Changed { get; private set; } = false;

    /// <summary>
    /// The preset colours.
    /// </summary>
    public static Dictionary<int, Color> PresetColours { get; private set; } = new Dictionary<int, Color>();
    #endregion
    #region Public
    /// <summary>
    /// Loads a grid from file and returns it.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static GridPanel LoadGrid(string filePath)
    {
      // Clear the grid.
      Grid?.Clear();

      // Convert file to grid.
      GridPanel grid = ConvertFileToGrid(filePath);
      Grid = grid;

      return grid;
    }

    /// <summary>
    /// Saves a grid to file.
    /// </summary>
    /// <param name="filePath"></param>
    public static void SaveGrid(string filePath)
    {
      List<string> lines = ConvertGridToFile(Grid);

      File.WriteAllLines(filePath, lines);
    }

    /// <summary>
    /// Creates a grid x by y with no specified colours.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static GridPanel CreateDefaultGrid(int x, int y)
    {
      GridPanel grid = CreateGrid(x, y, null);
      Grid = grid;
      return grid;
    }

    /// <summary>
    /// Sets the colour to be used in the system.
    /// </summary>
    /// <param name="colour"></param>
    public static void SetColour(Color colour) => UserHasSetColour?.Invoke(colour);

    /// <summary>
    /// Given a string of the correct form, parse it and return the represented colour.
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public static Color GetColour(string line)
    {
      // Get the individual values by spliting by comma
      string[] rgb = line.Replace("{", string.Empty).Replace("}", string.Empty).Split(',');

      // Parse the colour
      int r = int.Parse(rgb[0]);
      int g = int.Parse(rgb[1]);
      int b = int.Parse(rgb[2]);

      Color colour = Color.FromArgb(r, g, b);

      return colour;
    }

    /// <summary>
    /// Deletes the grid and resets the selected name.
    /// </summary>
    public static void Reset()
    {
      Grid = null;
      SelectedName = string.Empty;
    }

    /// <summary>
    /// Clears the grid back to its default colours.
    /// </summary>
    public static void ClearGrid()
    {
      Grid?.Clear();
    }

    /// <summary>
    /// Rotates the grid 90 degress to the right.
    /// </summary>
    /// <param name="gridPanel"></param>
    public static void RotateGrid()
    {
      Color[,] gridColours = Grid?.GetGridColours();

      if (gridColours is null) return;

      int row = gridColours.GetLength(0);
      int col = gridColours.GetLength(0);

      Color[,] rotatedGridColours = new Color[row, col];

      for (int y = 0; y < col; y++)
      {
        for (int x = 0; x < row; x++)
        {
          rotatedGridColours[y, col - 1 - x] = gridColours[x, y];
        }
      }

      Grid?.SetGridColours(rotatedGridColours);

      Grid?.AddToHistory();
    }

    /// <summary>
    /// Loads the preset colours from file.
    /// </summary>
    /// <param name="filePath"></param>
    public static void LoadPresetColoursFromFile(string filePath)
    {
      // Get the contents of the file

      // if the file is empty
      string[] lines = File.ReadAllLines(filePath);
      string jsonString = string.Empty;

      if(lines is null || lines.Length < 1)
      {
        jsonString = "{\"{1}\": \"{White}\"," +
                      "\"{2}\": \"{Black}\"," +
                      "\"{3}\": \"{Red}\"," +
                      "\"{4}\": \"{Green}\"," +
                      "\"{5}\": \"{Blue}\"," +
                      "\"{6}\": \"{Gold}\"," +
                      "\"{7}\": \"{Silver}\"," +
                      "\"{8}\": \"{Brown}\"," +
                      "\"{9}\": \"{Purple}\"}";
      }
      else
      {
        jsonString = lines.Aggregate((a, b) => a + b);
      }
      
      // Parse the file to a dictionary of preset coloues.
      Dictionary<int, string> intercept = JsonConvert.DeserializeObject<Dictionary<int, string>>(jsonString);

      Dictionary<int, Color> colours = new Dictionary<int, Color>();

      foreach (var pair in intercept)
      {
        Color colour = Color.FromArgb(0, 0, 0, 0);

        try
        {
          var maybeHex = ColorTranslator.FromHtml("#" + pair.Value);
          colour = maybeHex;
        }
        catch
        {
          // If we throw an exception we know it's a string with a name
          if (colour.A == 0 && colour.R == 0 && colour.G == 0 && colour.B == 0)
          {
            colour = Color.FromName(pair.Value);
          }
        }

        colours.Add(pair.Key, colour);
      }

      // Set the preset colours.
      PresetColours = colours;
    }

    /// <summary>
    /// Saves the preset colours back to file.
    /// </summary>
    public static void SavePresetColoursToFile(Dictionary<int, Color> colours)
    {
      var entries = colours.Select(d => string.Format("\"{0}\": \"{1}\"", d.Key, d.Value.Name));
      string returnString = "{" + string.Join(",", entries) + "}";
      returnString = returnString.JsonPrettify();

      File.WriteAllLines(Preset_Path, new string[1] { returnString });
    }
    #endregion
    #region Private
    /// <summary>
    /// Converts a file to a grid.
    /// </summary>
    /// <param name="filePath">The file path of the '.colours' file.</param>
    private static GridPanel ConvertFileToGrid(string filePath)
    {
      const int VARIABLE_LINE_INDEX = 3;

      // Parse the file into a collection of strings
      var lines = File.ReadAllLines(filePath).ToList();

      // Get the dimension of the grid
      string topLine = lines[VARIABLE_LINE_INDEX];

      string[] dimensionsString = topLine.Subsequence(topLine.LastIndexOf('_') + 1, topLine.LastIndexOf('[')).Split('x');
      int[] dimensions = new int[] { int.Parse(dimensionsString[0]), int.Parse(dimensionsString[1]) };

      // Get the first and last index of '{' & '}'
      int firstBracketIndex = lines.IndexOf("{");
      int lastBracketIndex = lines.LastIndexOf("};");

      List<string> newLines = new();

      // Append all the lines of strings from the first index to the next
      for (int i = firstBracketIndex; i < lastBracketIndex; i++)
        newLines.Add(lines[i]);

      string line = newLines.Aggregate((a, b) => a + b);

      // split the line by commas
      string[] rgbValues = Regex.Matches(line, @"\{.*?\}").Cast<Match>().Select(m => m.Value).ToArray();

      // Get rid of the tab escape in the first instance
      rgbValues[0] = rgbValues[0].Replace("\t", string.Empty);

      Color[,] colours = new Color[dimensions[0], dimensions[1]];

      int index = 0;

      for (int y = 0; y < dimensions[1]; y++)
      {
        for (int x = 0; x < dimensions[0]; x++)
        {
          colours[x, y] = GetColour(rgbValues[index++]);
        }
      }

      // Now we have all the colours set and represented in the colurs array, now render the grid.
      return CreateGrid(dimensions[0], dimensions[1], colours);
    }

    /// <summary>
    /// Creates a grid panel control.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="colours"></param>
    /// <returns></returns>
    private static GridPanel CreateGrid(int x, int y, Color[,] colours)
    {
      return new GridPanel(x , y , colours);
    }

    /// <summary>
    /// Converts the grid to an array of rbg values to be saved/transferred.
    /// </summary>
    /// <returns></returns>
    private static int[,,] ConvertGridToArray(GridPanel grid)
    {
      const int MAX_COLOUR_COUNT = 3;

      int x = grid.X_DIMENSION;
      int y = grid.Y_DIMENSION;

      int[,,] rgb = new int[x, y, MAX_COLOUR_COUNT];

      for (int col = 0; col < y; col++)
      {
        for (int row = 0; row < x; row++)
        {
          Color panelColour = Grid.Grid[row, col].BackColor;

          rgb[row, col, 0] = panelColour.R;
          rgb[row, col, 1] = panelColour.G;
          rgb[row, col, 2] = panelColour.B;
        }
      }

      return rgb;
    }

    /// <summary>
    /// Attempts to convert the grid to a '.colours' file.
    /// </summary>
    /// <param name="filePath">The lines that constitute the lines</param>
    private static List<string> ConvertGridToFile(GridPanel gridPanel)
    {
      string name = SelectedName;

      int[,,] grid = ConvertGridToArray(gridPanel);

      // Get the dimensions of the grid proposed.
      int x = grid.GetLength(0);
      int y = grid.GetLength(1);

      string dimensionsString = $"{ x }x{ y }";

      List<string> lines = new();

      lines.Add($"#define { name }_{ dimensionsString }_WIDTH { x }");
      lines.Add($"#define { name }_{ dimensionsString }_HEIGHT { y } \r\n");

      lines.Add($"const RGB_OBJ { name }_{ dimensionsString }[{ x * y }] = \n{{");

      for (int col = 0; col < y; col++)
      {
        for (int row = 0; row < x; row++)
        {
          string r = string.Format("{0, 4}", grid[row, col, 0]);
          string g = string.Format("{0, 4}", grid[row, col, 1]);
          string b = string.Format("{0, 4}", grid[row, col, 2]);

          if (row % x == 0)
            lines.Add($"\t{{{r},{g},{b}}},");
          else
            lines[lines.Count - 1] += $" {{{r},{g},{b}}},";
        }
      }

      lines.Add("};");

      return lines;
    }
    #endregion
  }
}
