using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _groundCheckRadius;
    private float _horisontalInput;
    private bool _isTurnedRight;

    [SerializeField]
    private Transform _groundCheckPoint;
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    [SerializeField]
    private LayerMask _ground;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();   
        _isTurnedRight = true;
    }

    private void Update()
    {
        _horisontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        bool isGrounded = IsGrounded();

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
            _animator.SetBool("isPlayerJump", true);
        }

        if (_rigidBody.velocity.y <= 0)
            _animator.SetBool("isPlayerJump", false);

        if (_horisontalInput == 0)
        {
            _animator.SetBool("isPlayerRun", false);
            return;
        }
        else
            _animator.SetBool("isPlayerRun", true);

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
        _animator.SetBool("isGrounded", answer);
        return answer;
    }
}
