using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnCursor : MonoBehaviour {
    public GameObject objectToSpawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0.0f;
            GameObject objectInstance = Instantiate(objectToSpawn, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }
}
