using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnGrass : MonoBehaviour {

    public GameObject grassPrefab;
    public Vector2 center;
    public Vector2 size;

    public Tile grass;

    public float time;
    public float timer;

    // Use this for initialization
    void Start () {
        SpawnTheGrass();
        time = 0f;
        timer = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timer += Time.deltaTime;
        Timer();
        if (timer > 150f)
        {
            var clones = GameObject.FindGameObjectsWithTag("grass");
            foreach(var clone in clones)
            {
                Destroy(clone);
            }
            timer = 0f;
            SpawnTheGrass();
        }
	}

    public void SpawnTheGrass()
    {
        for (int i = 0; i <= 4; i++)
        {
            Vector2 pos = center + new Vector2(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));
            Instantiate(grassPrefab, pos, Quaternion.identity);
        }
    }

    public void Timer()
    {
        if (time > 10f)
        {
            SpawnTheGrass();
            time = 0f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, .25f);
        Gizmos.DrawCube(center, size);
    }
}
