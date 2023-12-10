using UnityEngine;

namespace RobotV2
{
    public class RobotMiner : MonoBehaviour
    {
        private Wheel[] _wheels;

        private Pick _pick;

        private Camera _camera;

        public void Initialize()
        {
            _wheels = GetComponentsInChildren<Wheel>();
            _pick = GetComponentInChildren<Pick>();
            _camera = GetComponentInChildren<Camera>(); 
        }
    }
}