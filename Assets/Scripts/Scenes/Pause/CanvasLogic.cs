using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pause
{
    public class CanvasLogic : MonoBehaviour
    {
        public void LoadScene(int SceneIndex)
        {
            SceneManager.LoadScene(SceneIndex); 
        }
    }
}