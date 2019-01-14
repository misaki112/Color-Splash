using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour {

    public float spawnRate = 1f;

    public GameObject[] prefabs = new GameObject[6];

    public bool isHard;

    private float[] floats = new float[160];

    private float nextTimeToSpawn = 0f;

    private System.Random rnd = new System.Random();

    // Update is called once per frame
    void Start()
    {
        for (int i = 0; i < 160; i++)
        {
            floats[i] = -7.9f + i * 0.1f;
        } 
    }
    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            int num = 0;
            if (isHard)
            {
                num = rnd.Next(3);
            } else
            {
                num = rnd.Next(6);
            }
            int index = rnd.Next(160);
            float posX = floats[index];
            Vector3 vec = new Vector3(posX, 4.93f, 0f);
            GameObject pre = prefabs[num];
            Instantiate(pre, vec, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1 / spawnRate;
           
        }
    }
}
