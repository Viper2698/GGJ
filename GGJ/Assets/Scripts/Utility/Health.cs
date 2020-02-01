using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float barrelTime = 5f;
    float health = 100f;

    bool barrel = false;
    bool dead = false;

    private void Update()
    {
        UpdateBarrelTimer(barrel);
    }

    private void UpdateBarrelTimer(bool barrel)
    {
        //if(barrel)

    }

    private void Die()
    {
        //GetComponent<Animator>().SetTrigger("Die");
        dead = true;
    }

    public void TurnToBarrel()
    {
        // TODO: change animationto barrel
        // TODO: restrict player's movement
        // TODO: change player's tag

    }

    public bool IsDead()
    {
        return dead;
    }
}
