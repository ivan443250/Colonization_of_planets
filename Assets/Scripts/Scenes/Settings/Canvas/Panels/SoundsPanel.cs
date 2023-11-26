using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class SoundsPanel : MonoBehaviour
    {
        public float[] GetSettingsChanges => new float[] { _volumeSlider.value, _soundSlider.value, _musicSlider.value };

        [SerializeField]
        private Slider _volumeSlider;
        [SerializeField]
        private Slider _soundSlider;
        [SerializeField]
        private Slider _musicSlider;

        public void RecieveSettings(float[] sliderValues)
        {
            if (sliderValues != null && sliderValues.Length == 3)
            {
                _volumeSlider.value = sliderValues[0];
                _soundSlider.value = sliderValues[1];
                _musicSlider.value = sliderValues[2];
            }
            else
                ResetToDefaultSettings();
        }

        public void ResetToDefaultSettings()
        {
            _volumeSlider.value = DefaultSettings.SoundsSliders[0];
            _soundSlider.value = DefaultSettings.SoundsSliders[1];
            _musicSlider.value = DefaultSettings.SoundsSliders[2];
        }
    }
}
