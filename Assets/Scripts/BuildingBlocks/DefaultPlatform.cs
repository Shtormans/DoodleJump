using UnityEngine;

public class DefaultPlatform : MonoBehaviour, IPlatform
{
    public float YPosition => transform.position.y;

    public void DeleteSelf()
    {
        Destroy(this.gameObject);
    }

    public void LowerPosition(float yOffset)
    {
        transform.position = transform.position - Vector3.up * yOffset;
    }
}
