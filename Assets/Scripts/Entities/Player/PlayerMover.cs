using Unity.VisualScripting;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private ScreenSizes _screenSize;
    [SerializeField, Range(0f, 20f)] private float _speed = 0.01f;
    [SerializeField, Range(0f, 20f)] private float _jumpForce = 10f;
    
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        _collider.enabled = false;
    }

    private void LateUpdate()
    {
        if (!_collider.enabled && _rigidbody.velocity.y <= 0)
        {
            _collider.enabled = true;
        }

        if (transform.position.x > _screenSize.RightX)
        {
            transform.position = new Vector2(_screenSize.LeftX, transform.position.y);
        }
        else if (transform.position.x < _screenSize.LeftX)
        {
            transform.position = new Vector2(_screenSize.RightX, transform.position.y);
        }
    }

    public void MoveRight()
    {
        MoveLeftOrRight(Vector2.right);
    }

    public void MoveLeft()
    {
        MoveLeftOrRight(Vector2.left);
    }

    private void MoveLeftOrRight(Vector2 direction)
    {
        var offset = direction * _speed / 10;

        _rigidbody.transform.position = (Vector2)transform.position + offset;
    }
}