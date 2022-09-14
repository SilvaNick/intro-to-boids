using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpButton : MonoBehaviour
{
    public GameObject flock;
    [Range(1,10)] public int seconds;
    FlockBehavior originalBehavior;
    public FlockBehavior newBehavior;
    

    public void activatePowerUp()
    {
        StartCoroutine(GoToRed());
    }

    IEnumerator GoToRed()
    {
        originalBehavior = flock.GetComponent<Flock>().behavior;
        
        flock.GetComponent<Flock>().behavior = newBehavior;
        yield return new WaitForSeconds(seconds);
        flock.GetComponent<Flock>().behavior = originalBehavior;
    }
}
