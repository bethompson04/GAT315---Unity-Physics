using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] TMP_Text statusText;
    [SerializeField] float deadTimer = 1.0f;
    float timeElapsed;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger Enter");
        if (other.tag == "KillTarget")
        {
            Debug.Log("Box Entered");
            timeElapsed += Time.deltaTime;
            if (timeElapsed > deadTimer)
            { 
                statusText.text = "DRIVER - DEAD";
                statusText.color = Color.red;
            }
        }
    }
}
