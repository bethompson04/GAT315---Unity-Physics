using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Ammo : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float lifespan = 5;
    [SerializeField] AudioSource hitSound;

    Rigidbody rb;

    float timeElapsed = 0;

    void Start()
    {
        if (lifespan < 0) Destroy(gameObject);
        rb = GetComponent<Rigidbody>();

        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.VelocityChange);
        rb.AddForce(transform.rotation * Vector3.forward * speed, ForceMode.VelocityChange);

    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > lifespan) Destroy(gameObject);

    }
    void OnCollision(Collider other)
    {
        if (other.tag == "Target" || other.tag == "World")
            {
                hitSound.Play();
            }
    }
}