using UnityEngine;

namespace MainMenu
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private CanvasLogic _canvas;

        [SerializeField]
        private AudioSource _mainTheme;

        private void Start()
        {
            _canvas.Initialize();
            _mainTheme.volume = DataHolder.SettingsData.SoundsPanelDt.SoundSliderValues[2];
        }
    }
}

