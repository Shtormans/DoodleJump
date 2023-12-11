using UnityEngine;

public class ScreenSizes : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Vector2 _upperLeftCorner;
    private Vector2 _bottomRightCorner;

    public float Width => Mathf.Abs(LeftX - RightX);
    public float Height => Mathf.Abs(TopY - BottomY);

    public float XCenter => LeftX + Width / 2;
    public float HeightCenter => TopY - Height / 2;

    public float LeftX => _upperLeftCorner.x;
    public float RightX => _bottomRightCorner.x;
    
    public float TopY => _upperLeftCorner.y;    
    public float BottomY => _bottomRightCorner.y;    

    private void Awake()
    {
        _upperLeftCorner = _camera.ScreenToWorldPoint(new Vector3(0, _camera.pixelHeight, _camera.nearClipPlane));
        _bottomRightCorner = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, 0, _camera.nearClipPlane));
    }
}
