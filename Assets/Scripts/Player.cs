using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const string WALK_ANIMATION = "Walk";
    const string GROUND_TAG = "Ground";

    [SerializeField]
    private float _moveForce = 10f;
    [SerializeField]
    private float _jumpForce = 11f;
    [SerializeField]
    private float _minX;
    [SerializeField]
    private float _maxX;

    private float _movementX;
    private bool _isGrounded = true;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    private void FixedUpdate()
    {
    }

    void PlayerMoveKeyboard()
    {
        _movementX = Input.GetAxisRaw("Horizontal");
        Vector3 tempos = transform.position + new Vector3(_movementX, 0f, 0f) * _moveForce * Time.deltaTime;
        tempos.x = tempos.x < _minX ? _minX : tempos.x;
        tempos.x = tempos.x > _maxX ? _maxX : tempos.x;
        transform.position = tempos;
    }

    void AnimatePlayer()
    {
        if (_movementX != 0)
        {
            _animator.SetBool(WALK_ANIMATION, true);
            _spriteRenderer.flipX = _movementX < 0;
        } else
        {
            _animator.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            _isGrounded = true;
        }
    }
}
