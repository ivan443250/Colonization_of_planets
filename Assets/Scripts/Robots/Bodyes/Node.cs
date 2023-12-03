using UnityEngine;

namespace Robot
{
    public class Node : MonoBehaviour
    {
        private Transform _model;

        public void Initialize(Transform model)
        {
            _model = Instantiate(model, transform, false);
            _model.localPosition = Vector3.zero;
            _model.localRotation = Quaternion.identity;
        }
    }
}
