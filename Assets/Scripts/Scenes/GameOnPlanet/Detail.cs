using UnityEngine;

namespace GameOnPlanet
{
    public class Detail : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _gameManager.DetailsCount++;
            Destroy(gameObject);
        }
    }
}
