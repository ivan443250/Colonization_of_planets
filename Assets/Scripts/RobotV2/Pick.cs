using System.Runtime.CompilerServices;
using UnityEngine;

namespace RobotV2
{
    public class Pick : MonoBehaviour
    {
        public bool IsWork;

        private Animator _animator;

        public void Initialize()
        {
            _animator = GetComponent<Animator>();
            IsWork = false;
        }
    }
}
