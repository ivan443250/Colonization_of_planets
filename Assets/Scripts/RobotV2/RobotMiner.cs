using UnityEngine;
using UnityEngine.Events;

namespace RobotV2
{
    public class RobotMiner : MonoBehaviour
    {
        private Wheel[] _wheels;

        private Pick _pick;

        private Camera _camera;

        private UnityAction _action1;
        private UnityAction _action2;
        private UnityAction _action3;

        public void Initialize()
        {
            _wheels = GetComponentsInChildren<Wheel>();
            _pick = GetComponentInChildren<Pick>();
            _camera = GetComponentInChildren<Camera>(); 
        }

        private void DoAction1()
        {
           
        }

        private void DoAction2()
        {

        }

        private void DoAction3()
        {

        }
    }
}