using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bridge : MonoBehaviour
{
    [SerializeField] int woodNeeded = 0;
    [SerializeField] int ropeNeeded = 0;

    [SerializeField] Text alternativeText;
    [SerializeField] GameObject bridge;
    [SerializeField] Transform bridgeLocation;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Input.GetAxis("Interact") != 0)
            {
                var inventory = collision.gameObject.GetComponent<CharacterInteraction>();
                if (inventory.woodAmount >= woodNeeded
                    && inventory.ropeAmount >= ropeNeeded)
                {
                    inventory.woodAmount -= woodNeeded;
                    inventory.ropeAmount -= ropeNeeded;
                    Instantiate(bridge, bridgeLocation.position, bridgeLocation.rotation);
                    Destroy(gameObject);
                }
                else
                    alternativeText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            alternativeText.gameObject.SetActive(false);
        }
    }
}
