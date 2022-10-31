using UnityEngine;

namespace LiteNinja.Common
{
  public static class Utils
  {
    /// <summary>
    /// A palette of default colors.
    /// </summary>
    public static Color[] DefaultColors
    {
      get { return DefaultColorList.Clone() as Color[]; }
    }

    private static readonly Color[] DefaultColorList = new[]
    {
      ColorFromInt(202, 184, 12), //Old Gold
      ColorFromInt(106, 158, 146), //Polished Pine
      ColorFromInt(210, 237, 203), //Tea Green
      ColorFromInt(136, 177, 149), //Dark sea green
      ColorFromInt(193, 12, 8), //International Orange
      ColorFromInt(213, 51, 27), //Vermillion
      ColorFromInt(163, 210, 160), //Celadon
      ColorFromInt(61, 64, 48), //Rifle Green
      ColorFromInt(235, 234, 45), //Xanthic
      Color.black
    };



    private static Color ColorFromInt(int r, int g, int b)
    {
      return new Color(r / 255.0f, g / 255.0f, b / 255.0f);
    }
  }
}