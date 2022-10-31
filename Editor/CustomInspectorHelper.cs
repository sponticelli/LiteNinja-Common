using System.Linq;
using UnityEditor;
using UnityEngine;


namespace LiteNinja.Common.Editor
{
    public class CustomInspectorHelper : UnityEditor.Editor
    {
        private Texture2D lineTexture;

        private Texture2D LineTexture
        {
            get
            {
                if (lineTexture != null) return lineTexture;
                lineTexture = new Texture2D(1, 1);
                lineTexture.SetPixel(0, 0, new Color(37f / 255f, 37f / 255f, 37f / 255f));
                lineTexture.Apply();

                return lineTexture;
            }
        }

        protected void DrawLine()
        {
            var lineStyle = new GUIStyle
            {
                normal =
                {
                    background = LineTexture
                }
            };

            GUILayout.Space(3);
            GUILayout.BeginVertical(lineStyle);
            GUILayout.Space(1);
            GUILayout.EndVertical();
            GUILayout.Space(3);
        }

        protected void BeginBox(string boxTitle = "")
        {
            var style = new GUIStyle("HelpBox")
            {
                padding =
                {
                    left = 0,
                    right = 0
                }
            };

            GUILayout.BeginVertical(style);

            if (!string.IsNullOrEmpty(boxTitle))
            {
                DrawBoldLabel(boxTitle);
                DrawLine();
            }
        }

        protected void EndBox()
        {
            GUILayout.EndVertical();
        }

        protected void DrawBoldLabel(string text)
        {
            EditorGUILayout.LabelField(text, EditorStyles.boldLabel);
        }

        protected bool BeginFoldoutBox(string boxTitle)
        {
            var style = new GUIStyle("HelpBox")
            {
                padding =
                {
                    left = 15,
                    right = 0
                }
            };

            GUILayout.BeginVertical(style);

            if (string.IsNullOrEmpty(boxTitle)) return true;
            var wasExpanded = IsBoxExpanded(boxTitle);

            var isExpanded = DrawBoldFoldout(wasExpanded, boxTitle);

            if (wasExpanded == isExpanded) return isExpanded;
            if (isExpanded)
            {
                SetBoxExpanded(boxTitle);
            }
            else
            {
                SetBoxCollapsed(boxTitle);
            }

            return isExpanded;

        }

        protected bool BeginSimpleFoldoutBox(string boxTitle)
        {
            if (string.IsNullOrEmpty(boxTitle)) return true;
            var wasExpanded = IsBoxExpanded(boxTitle);
            var isExpanded = DrawBoldFoldout(wasExpanded, boxTitle);

            if (wasExpanded == isExpanded) return isExpanded;
            if (isExpanded)
            {
                SetBoxExpanded(boxTitle);
            }
            else
            {
                SetBoxCollapsed(boxTitle);
            }

            return isExpanded;

        }

        protected bool BeginSimpleFoldoutBox(string boxTitle, string toggleKey)
        {
            if (string.IsNullOrEmpty(boxTitle)) return true;
            var wasExpanded = IsBoxExpanded(toggleKey);
            var isExpanded = DrawBoldFoldout(wasExpanded, boxTitle);

            if (wasExpanded == isExpanded) return isExpanded;
            if (isExpanded)
            {
                SetBoxExpanded(toggleKey);
            }
            else
            {
                SetBoxCollapsed(toggleKey);
            }

            return isExpanded;

        }

        protected bool BeginFoldoutBox(string boxTitle, string toggleKey)
        {
            var style = new GUIStyle("HelpBox")
            {
                padding =
                {
                    left = 15,
                    right = 0
                }
            };

            GUILayout.BeginVertical(style);

            if (string.IsNullOrEmpty(toggleKey)) return true;
            var wasExpanded = IsBoxExpanded(toggleKey);

            var isExpanded = DrawBoldFoldout(wasExpanded, boxTitle);

            if (wasExpanded == isExpanded) return isExpanded;
            if (isExpanded)
            {
                SetBoxExpanded(toggleKey);
            }
            else
            {
                SetBoxCollapsed(toggleKey);
            }

            return isExpanded;

        }

        protected bool IsBoxExpanded(string key)
        {
            var editorExpandedBoxes = EditorPrefs.GetString("hb-toggle-on").Split(';');

            return editorExpandedBoxes.Any(t => t == key);
        }


        protected void SetBoxExpanded(string prefKey)
        {
            var boxExpandedStr = EditorPrefs.GetString("hb-toggle-on");

            if (!string.IsNullOrEmpty(boxExpandedStr))
            {
                boxExpandedStr += ";";
            }

            boxExpandedStr += prefKey;

            EditorPrefs.SetString("hb-toggle-on", boxExpandedStr);
        }

        protected void SetBoxCollapsed(string prefKey)
        {
            var editorExpandedBoxes = EditorPrefs.GetString("hb-toggle-on").Split(';');

            var expandName = "";

            foreach (var t in editorExpandedBoxes)
            {
                if (t == prefKey)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(expandName))
                {
                    expandName += ";";
                }

                expandName += t;
            }

            EditorPrefs.SetString("hb-toggle-on", expandName);
        }


        protected bool DrawBoldFoldout(bool isExpanded, string text)
        {
            var foldoutStyle = new GUIStyle(EditorStyles.foldout)
            {
                fontStyle = FontStyle.Bold
            };
            return EditorGUILayout.Foldout(isExpanded, text, foldoutStyle);
        }

        protected bool DrawAddElementButton(string btnText)
        {
            var bgColor = GUI.backgroundColor;

            GUI.backgroundColor = Color.grey;
            var style2 = new GUIStyle(GUI.skin.button)
            {
                richText = true
            };

            var isPressed = (GUILayout.Button("<b>" + btnText + "</b>", style2));
            GUI.backgroundColor = bgColor;
            return isPressed;
        }
    }
}
