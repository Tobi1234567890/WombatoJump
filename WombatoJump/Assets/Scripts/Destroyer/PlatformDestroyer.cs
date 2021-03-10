using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            PlatformSpawner.PlatformListSortedByVerticalPosition.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            SpawnManager.Instance.SpawnPlatforms();
        }
    }
}
