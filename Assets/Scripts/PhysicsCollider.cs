using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour
{
    [SerializeField] GameObject ContactFX;

    string status;
    Vector3 contact;
    Vector3 normal;

    private void OnCollisionEnter(Collision collision)
    {
        status = "Collision Enter:" + collision.gameObject.name;

        contact = collision.GetContact(0).point;
        normal = collision.GetContact(0).normal;

        Instantiate(ContactFX, contact, Quaternion.LookRotation(normal));
    }
    private void OnCollisionStay(Collision collision) 
    {
        status = "Collision Stay:" + collision.gameObject.name;
    }

    private void OnCollisionExit(Collision collision)
    {
        status = "Collision Exit:" + collision.gameObject.name;
    }



    private void OnTriggerEnter(Collider other)
    {
        status = "Trigger Enter:" + other.gameObject.name;
    }

    private void OnTriggerStay(Collider other)
    {
        status = "Trigger Stayr:" + other.gameObject.name;
    }

    private void OnTriggerExit(Collider other)
    {
        status = "Trigger Exit:" + other.gameObject.name;
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 16;
        Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);

        GUI.Label(new Rect(screen.x, Screen.height - screen.y / 2, 250, 70), status);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(contact, 0.1f);
        Gizmos.DrawLine(contact, contact + normal);
    }
}


