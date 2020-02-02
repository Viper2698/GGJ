using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Animator myAnimator;
    bool isJumping = false;
    float horizontal, vertical;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

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

    private void LateUpdate()
    {
        Quaternion rotation = new Quaternion(0, Camera.main.transform.rotation.y, 0, 1);
        GetComponent<Rigidbody>().MoveRotation(rotation);
    }

    void StopJump()
    {
        isJumping = false;
    }
}
