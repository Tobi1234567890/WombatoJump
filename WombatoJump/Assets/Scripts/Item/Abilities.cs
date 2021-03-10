using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType
{
    JumpShoes,
    Jetpack
}

public class Abilities : MonoBehaviour
{
    public static Abilities Instance;

    void Start()
    {
        Instance = this;
    }

    public void ActivateJumpShoes(float multiplier)
    {
        PlayerController.Instance.JumpBoostMultiplier = multiplier;

        void Action()
        {
            PlayerController.Instance.JumpBoostMultiplier = 1;
        }

        StartCoroutine(WaitAndPrint(5, Action));
    }

    public void ActivateJetPack(float timeToFly)
    {
        gameObject.GetComponent<PlayerController>().rig.velocity = Vector2.up * (timeToFly * Time.deltaTime);
    }

    private IEnumerator WaitAndPrint(float waitTime, Action actionAfterTime)
    {
        yield return new WaitForSeconds(waitTime);
        actionAfterTime?.Invoke();
    }
}
