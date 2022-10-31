using UnityEditor;
using UnityEngine;

namespace LiteNinja.Common.Editor
{
  public static class MenuItems
  {
    [MenuItem("LiteNinja/Tools/Delete Player Pref %#d")]
    public static void DeletePlayerPrefs()
    {
      PlayerPrefs.DeleteAll();
      Debug.Log("<color=#52D5F2>--Player Prefs deleted--</color>");
    }
  }
}