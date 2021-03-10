using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    public AbilityType AbilityType;
    public float JetPackPower;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Abilities>().ActivateJetPack(JetPackPower); 
            Destroy(gameObject);
        }
    }
}
