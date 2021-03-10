using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpShoes : MonoBehaviour
{
    public float JumpMultiplier;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Abilities>().ActivateJumpShoes(JumpMultiplier);
            Destroy(gameObject);
        }
    }

}
