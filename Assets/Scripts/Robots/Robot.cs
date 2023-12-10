using System.Diagnostics;
using UnityEngine;

namespace Robot
{
    public class Robot : MonoBehaviour
    {
        private Body _body;
        private Processor _processor;

        public void Initialize(RobotData robotData, RobotCollections robotCollections)
        {
            _body = new GameObject().AddComponent<Body>();
            _body.transform.parent = transform;
            _body.transform.localPosition = Vector2.zero;
            _body.transform.localRotation = Quaternion.identity;
            _body.Initialize(robotData, robotCollections);

            _processor = new GameObject().AddComponent<Processor>();
            _processor.transform.parent = transform;
            _processor.transform.localPosition = Vector2.zero;
            _processor.transform.localRotation = Quaternion.identity;
        }

        public void SaveData()
        {

        }
    }
}