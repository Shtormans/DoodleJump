using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private float _minDistance = 2f;
    [SerializeField] private float _maxDistance = 10f;
    [SerializeField] private GameObject _safePlatform;
    [SerializeField] private ScreenSizes _screenSizes;

    private RandomizeContainer<GameObject>[] _platforms;
    private Transform _lastPlatformTransform;

    public Vector3 LastPlatformPosition => _lastPlatformTransform.position;

    private void Start()
    {
        _platforms = new[]
        {
            new RandomizeContainer<GameObject>(_safePlatform, 1f)
        };
    }

    public IPlatform GenerateNewPlatform()
    {
        float distance = Random.Range(_minDistance, _maxDistance);
        float xPosition = Random.Range(_screenSizes.LeftX, _screenSizes.RightX);

        var spawnObject = Randomizer.MakeChoiceWithChances(_platforms);

        var nextPosition = new Vector2(xPosition, _lastPlatformTransform.position.y + distance);
        var platform = Instantiate(spawnObject, nextPosition, Quaternion.identity);

        _lastPlatformTransform = platform.transform;

        return platform.GetComponent<IPlatform>();
    }

    public IPlatform GenerateFirstPlatform()
    {
        var position = new Vector3(_screenSizes.XCenter, _screenSizes.BottomY, 0);
        var platform = Instantiate(_safePlatform, position, Quaternion.identity);
        
        _lastPlatformTransform = platform.transform;

        return platform.GetComponent<IPlatform>();
    }
}
