using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] float barrelTime = 5f;
    public TakeDamageEvent takeDamage;

    // this class was created because generics can't be serialized
    // this way the takeDamage variable will be serialized
    // no modification is done to the UnityEvent<float> class
    [Serializable]
    public class TakeDamageEvent : UnityEvent<float>
    {

    }

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
        Invoke("GameOver", 1f);
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void TurnToBarrel()
    {
        // TODO: change animationto barrel
        // TODO: restrict player's movement
        // TODO: change player's tag

    }

    public void Damage(float damage)
    {
        health = Mathf.Max(health - damage, 0);
        takeDamage.Invoke(damage);

        print(health);

        if (health == 0 && !dead)
        {
            //die.Invoke();
            Die();
        }
    }

    public bool IsDead()
    {
        return dead;
    }
}
