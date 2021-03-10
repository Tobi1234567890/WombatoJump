using Assets.Scripts.HelpScripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class PlatformSpawner : Spawner
{
    public Transform PlatformParentTransform;
    public Transform SpawnPositionCenter;

    public int PlatformsToSpawnAtStart = 10;
    public int MaxNumberOfPlatforms;
    public int HorizontalSpawnRange = 4;
    public int VerticalSpawnRange = 4;

    public static SortedSet<GameObject> PlatformListSortedByVerticalPosition;

    public static float lastPlatformVerticalPos;
    public static float lastPlatformHorizontalPos;

    private new void Start()
    {
        PlatformListSortedByVerticalPosition = new SortedSet<GameObject>(new VerticalPositionComparer());
        base.Start();

        PlatformListSortedByVerticalPosition.Add(GameObject.FindWithTag("Platform"));
        SpawnPlatformsAtStart(); 
    }
   

    public GameObject SpawnMaxNumberOfPlatforms()
    {
        int platformsToSpawn = GetNumberOfPlatformsToSpawn();
        GameObject lastSpawnedPlatform = null;

        for (int i = 0; i < platformsToSpawn; i++)
        {
            lastSpawnedPlatform = SpawnPlatform();
            lastPlatformVerticalPos = lastSpawnedPlatform.transform.position.y;
            lastPlatformHorizontalPos = lastSpawnedPlatform.transform.position.x;
        }

        return lastSpawnedPlatform;
    }

    public void SpawnPlatformsAtStart()
    {
        for(int i = 0; i < PlatformsToSpawnAtStart; i++)
        {
            GameObject spawnedPlatform = SpawnPlatform();
        }
    }

    private int GetNumberOfPlatformsToSpawn()
    {
        int platformsToSpawn = Mathf.Max(MaxNumberOfPlatforms - PlatformListSortedByVerticalPosition.Count, 0);

        return platformsToSpawn;
    }

    private GameObject SpawnPlatform()
    {
        Vector2 platformPos = 
            RandomCalculations.GetRandomPlatformSpawnPosition(PlatformListSortedByVerticalPosition.Last().transform.position, HorizontalSpawnRange,VerticalSpawnRange);

        GameObject spawnedPlatform = Instantiate(GetObjectToSpawn(), platformPos, Quaternion.identity, PlatformParentTransform);

        PlatformListSortedByVerticalPosition.Add(spawnedPlatform);

        return spawnedPlatform;
    }
}
