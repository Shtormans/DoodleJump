using UnityEngine;

public class Inputter : MonoBehaviour
{
    private PlayerMover _mover;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _mover.MoveLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _mover.MoveRight();
        }
    }
}