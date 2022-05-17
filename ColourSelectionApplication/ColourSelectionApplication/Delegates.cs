using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourSelectionApplication
{
  /// <summary>
  /// What colour has now been set?
  /// </summary>
  /// <param name="colour">The currently selected colour in the system.</param>
  public delegate void ColourSetCallback(Color colour);

  /// <summary>
  /// What name has now been set?
  /// </summary>
  /// <param name="variableName">The name of the constant varibale in the 'c' file.</param>
  public delegate void VariableNameSetCallback(string variableName);

  /// <summary>
  /// What preset colour has now been set/changed?
  /// </summary>
  /// <param name="presetIndex">The index of the preset colour.</param>
  /// <param name="colour">The colour the preset colout will be changed to.</param>
  public delegate void PresetColourSetCallback(int presetIndex, Color colour);

  /// <summary>
  /// Callback to resize the grid if the size of the gird exceeds the maximum viewable space within the 'MainPanel'.
  /// </summary>
  /// <param name="mainPanelSize">The size of the main panel.</param>
  /// <param name="panelSize">The size of the grid control.</param>
  public delegate void ReshapeChildPanelsCallback(Size mainPanelSize, Size panelSize);
}
