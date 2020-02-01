using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
  
        if(collision.gameObject.tag == "Wood")
        {
            Debug.Log("Detected object");

            if (Input.GetKey(KeyCode.V))
            {
                count++;
                Debug.Log(count);
                Debug.Log("pickedUp");
            }
        
        }
    }
}
