using System.Collections.Generic;
using UnityEngine;

public static class RandomCalculations
{
    public static Vector3 RandomInCircle(float xOffset, float yOffset)
    {
        float a = Random.Range(0, yOffset);
        Vector3 result = Random.insideUnitCircle;
        result.y = Mathf.Abs(result.y) * a;
        result.x = result.x * xOffset;

        return result;
    }

    private static float GetRandomHorizontalPlatformPosition(Vector2 lastPlatformPos, float horizontalOffset)
    {
        if (lastPlatformPos.x > 0)
        {
            return Random.Range(-horizontalOffset, -0.1f);
        }
        else
        {
            return Random.Range(horizontalOffset, 0.1f);
        }
    }

    private static float GetRandomVerticalPosition(Vector2 lastPlatformPos, float verticalOffset)
    {
        return lastPlatformPos.y + Random.Range(verticalOffset / 2, verticalOffset);
    }

    public static Vector2 GetRandomPlatformSpawnPosition(Vector2 lastPlatformPos, float horizontalOffset, float verticalOffset)
    {
        Vector2 platformPos = new Vector2
        {
            x = GetRandomHorizontalPlatformPosition(lastPlatformPos, horizontalOffset),
            y = GetRandomVerticalPosition(lastPlatformPos, verticalOffset)
        };

        return platformPos;
    }

    public static bool PercentageCalculations(int percent)
    {
        int percentRange = Random.Range(0, 100);

        return IsNumberInRange(0, percent, percentRange);
    }

    public static GameObject GetRandomElemntOfList(Dictionary<GameObject, int> ElementsWithPercent)
    {
        foreach (KeyValuePair<GameObject, int> element in ElementsWithPercent)
        {
            if (PercentageCalculations(element.Value))
            {
                return element.Key;
            }
        }

        return null;
    }


    private static bool IsNumberInRange(int minRange, int maxRange, int toCheck) => toCheck >= minRange && toCheck <= maxRange;
}
