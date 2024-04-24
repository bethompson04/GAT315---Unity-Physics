using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] Transform muzzle; // barrel
    [SerializeField] AudioSource audioSource;

    [SerializeField] bool equipped = false;
    void Update()
    {
        Debug.DrawRay(muzzle.position, muzzle.forward * 10, Color.red);

        if (equipped && Input.GetMouseButtonDown(0))
        {
            if (audioSource != null) audioSource.Play();
            Instantiate(ammo, muzzle.position, muzzle.rotation);
        }
    }
}
