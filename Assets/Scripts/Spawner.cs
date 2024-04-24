using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject SpawnPrefab;
    public KeyCode spawnKey;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(spawnKey))
        {
            Instantiate(SpawnPrefab, transform.position, transform.rotation);
        }
    }
}
