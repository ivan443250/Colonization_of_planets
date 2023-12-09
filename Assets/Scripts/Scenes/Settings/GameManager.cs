using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private CanvasLogic _canvas;

        [SerializeField]
        private AudioSource _mainTheme;

        [SerializeField]
        private Slider _musicSlider;

        private void Start()
        {
            _canvas.Initialize();
        }

        private void Update()
        {
            _mainTheme.volume = _musicSlider.value;
        }
    }
}
