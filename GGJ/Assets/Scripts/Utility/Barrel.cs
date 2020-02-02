using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] float maxBarrelTime = 5f;

    [SerializeField] GameObject player;
    [SerializeField] GameObject barrelPrefab;

    float barrelTime;
    GameObject barrel;
    bool isBarrel = false;
    bool buttonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        barrelTime = maxBarrelTime;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire2") != 0)
        {
            if (buttonPressed == false)
            {
                if (isBarrel == false)
                {
                    TurnToBarrel();
                }
                else
                    TurnToRobot();
                buttonPressed = true;
                isBarrel = !isBarrel;
                return;
            }
        }
        if (Input.GetAxis("Fire2") == 0)
        {
            buttonPressed = false;
        }
        CheckTimers();
    }

    private void CheckTimers()
    {
        if (isBarrel)
        {
            barrelTime -= Time.deltaTime;
            if (barrelTime < 0)
            {
                barrelTime = 0;
                TurnToRobot();
                isBarrel = false;
            }
        }
        else
        {
            barrelTime = Mathf.Min(barrelTime + Time.deltaTime, maxBarrelTime);
        }
    }

    private void TurnToBarrel()
    {
        barrel = Instantiate(barrelPrefab, player.transform.position, player.transform.rotation);
        player.SetActive(false);
        player.tag = "NotAPlayer";
    }

    private void TurnToRobot()
    {
        Destroy(barrel);
        player.SetActive(true);
        player.tag = "Player";
    }
}
