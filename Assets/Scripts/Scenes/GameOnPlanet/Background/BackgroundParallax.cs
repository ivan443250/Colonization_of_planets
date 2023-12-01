using System;
using UnityEngine;

namespace GameOnPlanet
{
    public class BackgroundParallax : MonoBehaviour
    {
        [SerializeField]
        private ParallaxLayer[] _parallaxLayers;

        [SerializeField]
        private Transform[] _immutableLayers;

        private Vector3 _lastCameraPosition;

        public void Initialize()
        {
            _lastCameraPosition = Camera.main.transform.position;
        }

        private void Update()
        {
            foreach (Transform layer in _immutableLayers)
                layer.position = new Vector3(Camera.main.transform.position.x, layer.position.y, layer.position.z);

            
        }

        private void FixedUpdate()
        {
            Vector3 Direction = Camera.main.transform.position - _lastCameraPosition;
            _lastCameraPosition = Camera.main.transform.position;

            foreach (ParallaxLayer layer in _parallaxLayers)
                layer.Move(Camera.main.transform.position);
        }
    }
}
