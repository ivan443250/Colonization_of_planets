using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameOnPlanet
{
    public class CanvasLogic : MonoBehaviour
    {
        [SerializeField] 
        private Button _interactionButton;

        [SerializeField]
        private GameObject _dialogPanel1;

        [SerializeField]
        private GameObject _dialogPanel2;

        public void Initialize(UnityEvent show, UnityEvent hide)
        {
            _interactionButton.gameObject.SetActive(false);
            show.AddListener(ShowInteractionButton);
            hide.AddListener(HideInteractionButton);
            _dialogPanel2.SetActive(false);
        }

        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void CloseDialogPanel1()
        {
            _dialogPanel1.gameObject.SetActive(false);
            _dialogPanel2.SetActive(true);
        }

        public void CloseDialogPanel2()
        {
            _dialogPanel2.gameObject.SetActive(false);
            ShowInteractionButton();
        }

        private void ShowInteractionButton()
        {
            _interactionButton.gameObject.SetActive(true);
        }

        private void HideInteractionButton()
        {
            _interactionButton.gameObject.SetActive(false);
        }
    }
}

