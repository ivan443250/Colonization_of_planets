using UnityEngine;

namespace RobotV2
{
    public class RobotCollector : MonoBehaviour
    {
        private Wheel[] _wheels;

        private Chest _chest;

        private Camera _camera;

        public void Start()
        {
            _wheels = GetComponentsInChildren<Wheel>();
            _chest = GetComponentInChildren<Chest>();
            _camera = GetComponentInChildren<Camera>();
        }
    }
}
