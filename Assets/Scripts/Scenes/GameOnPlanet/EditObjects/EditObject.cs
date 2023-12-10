using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GameOnPlanet
{
    public class EditObject : MonoBehaviour
    {
        [SerializeField]
        private CanvasLogic _editButton;
        protected bool _isEditing;
        [SerializeField]
        private string _buttonText;

        private UnityEvent _action;

        protected void Initialise(out UnityEvent doAction)
        {
            _isEditing = false;

            _action = new UnityEvent();

            doAction = _action;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerController playerController))
            {
                _isEditing = true;
                _editButton.OpenInteractionButton(_buttonText, out UnityEvent clickButton);
                clickButton.RemoveAllListeners();
                clickButton.AddListener(DoAction);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerController playerController))
            {
                _isEditing = false;
                _editButton.CloseInteractionButton();
            }
        }

        private void DoAction()
        {
            _action.Invoke();
        }
    }
}
