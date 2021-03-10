using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour
{
    public float speed;

    public Transform[] moveSpots;
    private int randomSpot;

    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);    
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        //print(Vector2.Distance(transform.position, moveSpots[randomSpot].position));
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            print("Whyyyyyy-----------------------------");
            randomSpot = Random.Range(0, moveSpots.Length);
        }
    }
}
