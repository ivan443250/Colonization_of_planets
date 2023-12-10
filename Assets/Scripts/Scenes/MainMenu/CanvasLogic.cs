using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class CanvasLogic : MonoBehaviour
    {
        [SerializeField]
        private Button _continueButton;
        [SerializeField]
        private Button _newGameButton;
        [SerializeField]
        private Button _settingsButton;
        [SerializeField]
        private Button _exitButton;

        public void Initialize()
        {
            _continueButton.onClick.AddListener(LoadGameCellsScene);
            _newGameButton.onClick.AddListener(LoadNewGame);
            _settingsButton.onClick.AddListener(LoadSettingsScene);
            _exitButton.onClick.AddListener(CloseGame);
        }

        public void LoadNewGame()
        {
            SaveSystem.Delete(SaveFilenames.GameData);
            SceneManager.LoadScene(5);
        }

        private void LoadGameCellsScene()
        {
            if (DataHolder.GameData.IsStartMoveWhatched == false)
                SceneManager.LoadScene(5);
            else
                SceneManager.LoadScene(1);
        }

        private void LoadSettingsScene()
        {
            SceneManager.LoadScene(3);
        }

        private void CloseGame()
        {
            Application.Quit();
        }
    }
}