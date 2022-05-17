using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourSelectionApplication
{
  public static class StaticStringClass
  {
    /// <summary>
    /// returns a section of a string from a string.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public static string Subsequence(this string str, int start, int end)
    {
      string newStr = string.Empty;

      for (int i = start; i < end; i++)
        newStr += str[i];

      return newStr;
    }

    /// <summary>
    /// Formats the Json string.
    /// </summary>
    /// <param name="json"></param>
    /// <returns>A formatted json string.</returns>
    public static string JsonPrettify(this string json)
    {
      using (var stringReader = new StringReader(json))
      using (var stringWriter = new StringWriter())
      {
        var jsonReader = new JsonTextReader(stringReader);
        var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
        jsonWriter.WriteToken(jsonReader);
        return stringWriter.ToString();
      }
    }
  }
}
