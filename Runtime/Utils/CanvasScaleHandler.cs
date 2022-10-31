using UnityEngine;
using UnityEngine.UI;

namespace LiteNinja.Common
{
    [RequireComponent(typeof(CanvasScaler))]
    public class CanvasScaleHandler : MonoBehaviour
    {
        private void Awake()
        {
            var screenAspect = (Screen.height > Screen.width)
                ? Screen.height / (float)Screen.width
                : Screen.width / (float)Screen.height;
            GetComponent<CanvasScaler>().matchWidthOrHeight = screenAspect < 1.75f ? 1.0f : 0.5f;
        }
    }
}