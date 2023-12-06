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
            _newGameButton.onClick.AddListener(LoadGameCellsScene);
            _settingsButton.onClick.AddListener(LoadSettingsScene);
            _exitButton.onClick.AddListener(CloseGame);
        }

        private void LoadGameCellsScene()
        {
            SceneManager.LoadScene(5);
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