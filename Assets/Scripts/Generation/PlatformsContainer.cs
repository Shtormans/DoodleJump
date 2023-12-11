using System.Collections.Generic;

public class PlatformsContainer
{
    private LinkedList<IPlatform> _platforms;

    public PlatformsContainer()
    {
        _platforms = new LinkedList<IPlatform>();
    }

    public void AddPlatform(IPlatform platform)
    {
        _platforms.AddLast(platform);
    }

    public void LowerPlatforms(float offset)
    {
        foreach (var platform in _platforms)
        {
            platform.LowerPosition(offset);
        }
    }

    public int RemovePlatformsBellowY(float y)
    {
        if (_platforms.Count == 0)
        {
            return 0;
        }

        var platformNode = _platforms.First;
        int deletionCount = 0;

        while (platformNode.Value.YPosition <= y)
        {
            platformNode.Value.DeleteSelf();

            if (_platforms.Count == 0)
            {
                break;
            }

            platformNode = platformNode.Next;

            _platforms.RemoveFirst();
            deletionCount++;
        }

        return deletionCount;
    }
}