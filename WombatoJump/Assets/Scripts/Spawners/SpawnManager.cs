using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    protected const int SPAWN_HEIGHT_OFFSET = 36;
    public static SpawnManager Instance;
    public Spawner[] CollectAbleSpawaners;
    public PlatformSpawner PlatformSpawner;

    private void Start()
    {
        Instance = this;
    }
    public void SpawnPlatforms()
    {
        GameObject platform = PlatformSpawner.SpawnMaxNumberOfPlatforms();
        GameObject objectToSpawn = GetSpawnObject();

        if(objectToSpawn != null && platform != null)
        {
            AddSpawnObjectToItem(platform, objectToSpawn);
        }
    }

    private void AddSpawnObjectToItem(GameObject platform, GameObject spawnObject)
    {
        GameObject spawnedItem = Instantiate(spawnObject);
        spawnedItem.transform.parent = platform.transform;
        spawnedItem.transform.localPosition = new Vector2(0, SPAWN_HEIGHT_OFFSET);
    }

    private GameObject GetSpawnObject()
    {
        GameObject objectToSpawn = null;

        foreach (Spawner spawner in CollectAbleSpawaners)
        {
            objectToSpawn = spawner.GetObjectToSpawn();

            if (objectToSpawn != null) break;
        }

        return objectToSpawn;
    }
}
