using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> SpawnObjectList;
    public List<int> ObjectSpawnPercentage;
    public GameObject DefaultSpawnObject = null;

    protected Dictionary<GameObject, int> spawnObjectsAndSpawnPercentage;

    public void Start()
    {
        FillSpawnObjectAndSpawnChanceDictionary();
    }

    public void FillSpawnObjectAndSpawnChanceDictionary()
    {
        spawnObjectsAndSpawnPercentage = new Dictionary<GameObject, int>();
        for (int i = 0; i < SpawnObjectList.Count; i++)
        {
            spawnObjectsAndSpawnPercentage.Add(SpawnObjectList[i], ObjectSpawnPercentage[i]);
        }
    }

    public GameObject GetObjectToSpawn()
    {
        return RandomCalculations.GetRandomElemntOfList(spawnObjectsAndSpawnPercentage) ?? DefaultSpawnObject;
    }
}
