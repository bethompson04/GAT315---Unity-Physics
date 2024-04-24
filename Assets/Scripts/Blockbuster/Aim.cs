using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] float aimSpeed = 3;
    [SerializeField] float yawLimit = 50;
    [SerializeField] float pitchLimit = 50;

    Vector3 rotation = Vector3.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 axis = Vector3.zero;
        axis.x = -Input.GetAxis("Mouse Y");
        axis.y = Input.GetAxis("Mouse X");


        rotation.x += axis.x * aimSpeed;
        rotation.y += axis.y * aimSpeed;

        rotation.x = Mathf.Clamp(rotation.x, -pitchLimit, pitchLimit);
        rotation.y = Mathf.Clamp(rotation.y, -yawLimit, yawLimit);

        Quaternion qYaw = Quaternion.AngleAxis(rotation.y, Vector3.up);
        Quaternion qPitch = Quaternion.AngleAxis(rotation.x, Vector3.right);

        transform.localRotation = (qYaw * qPitch);
    }
}
