using System;
using UnityEngine;

namespace comunication
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _maxSpeed;
        [SerializeField, Range(0f, 2f)]
        private float _currentSpeedChange;
        [SerializeField, Range(0f, 1f)]
        private float _defaultSpeedChange;
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

        private KeyCode _leftKey;
        private KeyCode _rightKey;
        private KeyCode _jumpKey;
        private KeyCode _runKey;

        public void Initialize()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _isTurnedRight = true;
            _currentAdditionalJumps = _maxAdditionalJumps;
            SettingsData _settingsData = DataHolder.SettingsData;
            _leftKey = _settingsData.ControlKeys[0];
            _rightKey = _settingsData.ControlKeys[1];
            _jumpKey = _settingsData.ControlKeys[2];
            _runKey = _settingsData.ControlKeys[3];
        }

        private void Update()
        {
            bool isGrounded = IsGrounded();

            if (isGrounded)
            {
                _currentAdditionalJumps = _maxAdditionalJumps;
                _isMainJumpStay = true;
            }

            if (Input.GetKeyDown(_jumpKey))
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
            if (Input.GetKey(_leftKey) && Input.GetKey(_rightKey) == false)
            {
                if (_horisontalInput > 0)
                    _horisontalInput = 0;
                if (_horisontalInput > -_maxSpeed)
                    _horisontalInput -= _currentSpeedChange;
            }
            else if (Input.GetKey(_rightKey) && Input.GetKey(_leftKey) == false)
            {
                if (_horisontalInput < 0)
                    _horisontalInput = 0;
                if (_horisontalInput < _maxSpeed)
                    _horisontalInput += _currentSpeedChange;
            }
            else
                _horisontalInput = 0f;

            if (_rigidBody.velocity.y <= 0)
                _animator.SetBool(PlayerAnimatorParameters.IsJump, false);

            if (_horisontalInput == 0)
            {
                _animator.SetBool(PlayerAnimatorParameters.IsRun, false);
                return;
            }
            else
                _animator.SetBool(PlayerAnimatorParameters.IsRun, true);

            Vector2 moveX = new Vector2(_horisontalInput, _rigidBody.velocity.y);

            if (moveX.x > 0 && _isTurnedRight == false)
            {
                Flip();
            }
            else if (moveX.x < 0 && _isTurnedRight)
            {
                Flip();
            }

            _rigidBody.velocity = moveX;
            if (_horisontalInput > 0)
                _horisontalInput -= _defaultSpeedChange;
            else if (_horisontalInput < 0)
                _horisontalInput += _defaultSpeedChange;
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
