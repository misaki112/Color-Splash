using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour {

    public float spawnRate = 1f;

    public GameObject Prefab;

    private float[] floats = new float[160];

    private float nextTimeToSpawn = 0f;

    private System.Random rnd = new System.Random();

    void Start()
    {
        for (int i = 0; i < 160; i++)
        {
            floats[i] = -7.9f + i * 0.1f;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            int index = rnd.Next(160);
            float posX = floats[index];
            Vector3 vec = new Vector3(posX, 4.93f, 0f);
            GameObject rec = Instantiate(Prefab, vec, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1 / spawnRate;
        }
    }

}

