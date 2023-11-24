using UnityEngine;

namespace Robot
{
    public class Robot : MonoBehaviour
    {
        private Body _body;
        private Processor _processor;
        private AdditionalDetail[] _additionalDetails;

        private void Start()
        {
            _body = GetComponentInChildren<Body>();
            _body.Initialize(out Transform initBodyModel);
            initBodyModel.SetParent(transform);
            initBodyModel.localPosition = transform.position;
            initBodyModel.rotation = Quaternion.identity;
        }
    }
}