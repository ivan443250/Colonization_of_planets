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

        public void Initialize(UnityEvent show, UnityEvent hide)
        {
            _interactionButton.gameObject.SetActive(false);
            show.AddListener(ShowInteractionButton);
            hide.AddListener(HideInteractionButton);
        }

        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
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

