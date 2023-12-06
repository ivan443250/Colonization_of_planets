using UnityEngine;

namespace Robot
{
    public class AdditionalDetail : MonoBehaviour
    {
        private Transform _model;

        protected void InstanceModel(Transform model)
        {
            _model = Instantiate(model, transform, false);
            _model.localPosition = Vector3.zero;
            _model.localRotation = Quaternion.identity;
        }

        protected void RotateModel(float rotationForce, int rotationDirection)
        {
            _model.Rotate(new Vector3(0f, 0f, 1f * rotationForce * rotationDirection), Space.Self);
        }
    }
}
