using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    public static class DefaultSettings
    {
        public static int CurrentSelectedPanel = 0;
        public static bool IsSynchronizationToggleOn = true;
        public static int SelectedGraphicIndex = 1;
        public static KeyCode[] ControlKeys => new KeyCode[] { KeyCode.A, KeyCode.D,  KeyCode.Space, KeyCode.LeftShift};
        public static float[] SoundsSliders = new float[] { 1f, 1f, 1f };
    }
}
