using UnityEngine;

namespace GameOnPlanet
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _jumpForce;
        [SerializeField]
        private float _groundCheckRadius;
        [SerializeField]
        private int _maxAdditionalJumps;
        private int _currentAdditionalJumps;
        private float _horisontalInput;
        private bool _isTurnedRight;
        private bool _isMainJumpStay;

        [SerializeField]
        private Transform _groundCheckPoint;
        private Rigidbody2D _rigidBody;
        private Animator _animator;
        [SerializeField]
        private LayerMask _ground;

        public void Initialize()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _isTurnedRight = true;
            _currentAdditionalJumps = _maxAdditionalJumps;
        }

        private void Update()
        {
            _horisontalInput = Input.GetAxis(InputConstants.Horizontal);
            bool isGrounded = IsGrounded();

            if (isGrounded)
            {
                _currentAdditionalJumps = _maxAdditionalJumps;
                _isMainJumpStay = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded && _isMainJumpStay)
                {
                    Jump();
                    _isMainJumpStay = false;
                }
                else if (_currentAdditionalJumps > 0)
                {
                    Jump();
                    _currentAdditionalJumps--;
                }
            }
        }

        private void FixedUpdate()
        {
            if (_rigidBody.velocity.y <= 0)
                _animator.SetBool(PlayerAnimatorParameters.IsJump, false);

            if (_horisontalInput == 0)
            {
                _animator.SetBool(PlayerAnimatorParameters.IsRun, false);
                return;
            }
            else
                _animator.SetBool(PlayerAnimatorParameters.IsRun, true);

            Vector2 moveX = new Vector2(_horisontalInput * _speed, _rigidBody.velocity.y);

            if (moveX.x > 0 && _isTurnedRight == false)
            {
                Flip();
            }
            else if (moveX.x < 0 && _isTurnedRight)
            {
                Flip();
            }

            _rigidBody.velocity = moveX;
        }

        private void Jump()
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
            _animator.SetBool(PlayerAnimatorParameters.IsJump, true);
        }

        private void Flip()
        {
            _isTurnedRight = !_isTurnedRight;
            Vector2 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        private bool IsGrounded()
        {
            bool answer = false;
            if (Physics2D.OverlapCircle(_groundCheckPoint.position, _groundCheckRadius, _ground))
                answer = true;
            _animator.SetBool(PlayerAnimatorParameters.IsGrounded, answer);
            return answer;
        }
    }
}
