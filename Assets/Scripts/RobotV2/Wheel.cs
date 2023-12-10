using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace RobotV2
{
    public class Wheel : MonoBehaviour
    {
        public bool IsRotate;

        private Animator _animator;

        public void Initialize()
        {
            _animator = GetComponent<Animator>();
            IsRotate = false;
        }

        public void StartRotation()
        {
            _animator.SetBool("IsRotate", true);
            IsRotate = true;
        }

        public void EndRotation()
        {
            _animator.SetBool("IsRotate", false);
            IsRotate = false;
        }
    }
}