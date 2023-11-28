using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class SoundsPanel : MonoBehaviour
    {
        public SoundsPanelData GetSettingsChanges => new SoundsPanelData(new float[] { _sliders[0].value, _sliders[1].value, _sliders[2].value });

        [SerializeField]
        private Slider[] _sliders;

        public void RecieveSettings(SoundsPanelData soundsPanelData)
        {
            for (int i = 0; i < _sliders.Length; i++)
                _sliders[i].value = soundsPanelData.SoundSliderValues[i];
        }

        public void ResetToDefaultSettings()
        {
            for (int i = 0;  i < _sliders.Length; i++)
                _sliders[i].value = DefaultSettings.SoundsSlidersValues[i];
        }
    }
}
