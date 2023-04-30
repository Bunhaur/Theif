using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private float _speed;
    private int _hashRunAnimator;

    private void Awake()
    {
        _speed = 3.0f;
        _hashRunAnimator = Animator.StringToHash("isRun");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _animator.SetBool(_hashRunAnimator, true);
        }
        else
        {
            _animator.SetBool(_hashRunAnimator, false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            transform.Translate(1 * _speed * Time.deltaTime, 0, 0);
        }
    }
}