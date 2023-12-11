using UnityEngine;

public class LevelObserver : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField, Range(0, 10)] private float _platformsSpeed = 10;

    private LevelGenerator _levelGenerator;
    private PlatformsContainer _platformsContainer;
    private ScreenSizes _screenSizes;
    private float _maxPlayerHeight;

    private void Awake()
    {
        _levelGenerator = GetComponent<LevelGenerator>();
        _platformsContainer = new PlatformsContainer();
        _screenSizes = GetComponent<ScreenSizes>();
    }

    private void Start()
    {
        _maxPlayerHeight = _screenSizes.BottomY + _screenSizes.Height / 3 * 2;

        var platform = _levelGenerator.GenerateFirstPlatform();
        _platformsContainer.AddPlatform(platform);

        GenerateAllPlatforms();
    }

    private void GenerateAllPlatforms()
    {
        while (_levelGenerator.LastPlatformPosition.y <= _screenSizes.TopY)
        {
            GenerateNewPlatform();
        }
    }

    private void GenerateNewPlatform()
    {
        var platform = _levelGenerator.GenerateNewPlatform();
        _platformsContainer.AddPlatform(platform);
    }

    private void LateUpdate()
    {
        if (_player.Position.y >= _maxPlayerHeight)
        {
            _player.StopAtHeight(_maxPlayerHeight);

            _platformsContainer.LowerPlatforms(_player.Velocity.y * _platformsSpeed * 0.01f);
            int deletionCount = _platformsContainer.RemovePlatformsBellowY(_screenSizes.BottomY);

            for (int i = 0; i < deletionCount; i++)
            {
                GenerateNewPlatform();
            }
        }
    }
}
