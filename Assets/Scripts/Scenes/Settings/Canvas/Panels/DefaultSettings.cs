using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    public static class DefaultSettings
    {
        public const int CurrentSelectedPanel = 0;

        public const bool IsSynchronizationToggleOn = true;
        public const int SelectedGraphicIndex = 1;

        public static KeyCode[] ControlKeys => new KeyCode[] { KeyCode.A, KeyCode.D,  KeyCode.Space, KeyCode.LeftShift};
        public static float[] SoundsSlidersValues = new float[] { 1f, 1f, 1f };
    }
}
