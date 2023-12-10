using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GameOnPlanet
{
    public class Rocket : EditObject
    {
        private void Start()
        {
            Initialise(out UnityEvent action);
            action.AddListener(DoAction);
        }

        private void DoAction()
        {
            if (_isEditing)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
