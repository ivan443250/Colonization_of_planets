using UnityEngine;
using UnityEngine.Events;

namespace GameOnPlanet
{
    public class Rocket : MonoBehaviour
    {
        private UnityEvent _playerEntered;
        private UnityEvent _playerExited;

        public void Initialize(out UnityEvent playerEntered, out UnityEvent playerExited)
        {
            _playerEntered = new UnityEvent();
            _playerExited = new UnityEvent();
            playerEntered = _playerEntered;
            playerExited = _playerExited;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _playerEntered.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _playerExited.Invoke();
            }
        }
    }
}
