using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GameOnPlanet
{
    public class ParallaxLayer : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)]
        private float _parallaxStrength;

        public void Move(Vector3 direction)
        {
            transform.position = new Vector3(direction.x * _parallaxStrength * -1, transform.position.y, transform.position.z);
        }
    }
}
