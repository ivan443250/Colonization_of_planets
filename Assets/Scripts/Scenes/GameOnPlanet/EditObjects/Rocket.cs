using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GameOnPlanet
{
    public class Rocket : MonoBehaviour
    {
        [SerializeField]
        private CanvasLogic _editButton;
        private bool _isEditButtonFocused = false;
        protected string _buttonText = "Войти в ракету";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerController playerController))
            {
                _isEditButtonFocused = true;
                _editButton.ChangeInteractionButton(true, _buttonText, out UnityEvent clickButton);
                clickButton.AddListener(DoAction);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerController playerController))
            {
                _isEditButtonFocused = false;
                _editButton.ChangeInteractionButton(false, _buttonText, out UnityEvent clickButton);
            }
        }

        private void DoAction() 
        {
            SceneManager.LoadScene(2);
        }
    }
}
