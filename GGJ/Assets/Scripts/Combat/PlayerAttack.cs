using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawner;
    [SerializeField] float bulletSpeed = 10f;

    bool fired = false;
    Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            if (fired == false)
            {
                myAnimator.SetTrigger("Fire");
                fired = true;
            }
        }
        if (Input.GetAxisRaw("Fire1") == 0)
        {
            fired = false;
        }
    }

    void Hit()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        bullet.transform.parent = bulletSpawner.transform;
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
}
