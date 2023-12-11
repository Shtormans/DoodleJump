using UnityEngine;

public interface IPlatform
{
    float YPosition { get; }

    void LowerPosition(float yOffset);

    void DeleteSelf();
}
