using UnityEngine;

public enum PlatformTypes
{
    DefaultPlatform = 1400,
    BouncePlatform = 2100,
    WidePlatform = 2100
}

public class PlatformScript : MonoBehaviour
{
    public PlatformTypes PlatformType;
}
