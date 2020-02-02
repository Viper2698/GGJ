using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    float vertical;

    // Update is called once per frame
    void Update()
    {

        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {


       GetComponent<Rigidbody>().MovePosition(transform.position 
                                            + vertical * transform.forward * Time.fixedDeltaTime * speed
                                            );
    }
}
