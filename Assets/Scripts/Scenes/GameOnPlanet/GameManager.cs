using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GameOnPlanet
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private CanvasLogic _canvas;
        [SerializeField]
        private PlayerController _playerController;

        [SerializeField]
        private AudioSource _gameTheme;

        [SerializeField]
        private DialogManager _dialogManager;

        public int DetailsCount;

        private void Start()
        {
            DetailsCount = 0;

            _dialogManager.Initialize(out UnityEvent startDialog, out UnityEvent endDialog);
            _canvas.Initialize(endDialog, startDialog);
            _playerController.Initialize(endDialog, startDialog);
            _gameTheme.volume = DataHolder.SettingsData.SoundsPanelDt.SoundSliderValues[2];

            if (DataHolder.GameData.EducationDialogsIndexes[0] == false)
                _dialogManager.StartDialog(0);
        }

        private void Update()
        {
            if (DetailsCount == 4)
                _canvas.IsDetailsCollected = true;
        }
    }
}
