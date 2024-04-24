using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] TMP_Text pointsText;
    [SerializeField] float pointValue = 10;
    [SerializeField] float deadTimer = 1.0f;

    float timeElapsed;

    private void OnTriggerStay(Collider other)
    {
       if (other.tag == "KillTarget")
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > deadTimer)
            {
                int prevScore = int.Parse(pointsText.text);
                pointsText.text = (prevScore + pointValue).ToString();
                Debug.Log(pointValue);
                Destroy(gameObject);
            }
        }
    }
}
