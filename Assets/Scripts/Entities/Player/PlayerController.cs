using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public Vector2 Position => transform.position;
    public Vector3 Velocity => _rigidbody.velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void StopAtHeight(float height)
    {
        transform.position = new Vector3(transform.position.x, height);
    }
}
