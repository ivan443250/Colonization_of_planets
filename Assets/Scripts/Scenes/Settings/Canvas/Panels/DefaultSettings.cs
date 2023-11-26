using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    public static class DefaultSettings
    {
        public static KeyCode[] ControlKeys => new KeyCode[] { KeyCode.A, KeyCode.D,  KeyCode.Space, KeyCode.LeftShift};
        public static List<float> SoundsSliders = new List<float>() { 1f, 0.5f, 0.5f };
    }
}
