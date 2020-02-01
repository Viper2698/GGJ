using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bridge : MonoBehaviour
{
    [SerializeField] Text alternativeText;
    [SerializeField] GameObject bridge;
    [SerializeField] Transform bridgeLocation;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Input.GetAxis("Interact") != 0)
            {
                // if player doesnt have the required items then sho wthe alternative text
                alternativeText.gameObject.SetActive(true);
                // else spawn the bridge
                Instantiate(bridge, bridgeLocation.position, bridgeLocation.rotation);
                Destroy(gameObject);
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
