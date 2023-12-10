using UnityEngine;
using UnityEngine.Events;
using static Unity.Collections.AllocatorManager;

namespace RobotV2
{
    public class RobotMiner : MonoBehaviour
    {
        private Wheel[] _wheels;

        private Pick _pick;

        private CameraTrigger _camera;

        private Transform _blocks;

        private bool _doAction;
        private bool _run;

        public void Initialize(UnityEvent startAction, UnityEvent stopAction, Transform blocks)
        {
            _blocks = blocks;
            _run = true;
            _wheels = GetComponentsInChildren<Wheel>();
            _pick = GetComponentInChildren<Pick>();
            _camera = GetComponentInChildren<CameraTrigger>();
            startAction.AddListener(DoAction);
            stopAction.AddListener(StopAction);
        }

        public void DoAction()
        {
            _doAction = true;

            Vector2 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        public void StopAction()
        {
            _doAction = false;
        }

        private void Update()
        {
            if (_doAction && _run)
                transform.Translate(Vector3.left * Time.deltaTime * 2);

            if (transform.position.x < -377f)
            {
                _run = false;
                Destroy(_blocks.gameObject);
            }
        }
    }
}