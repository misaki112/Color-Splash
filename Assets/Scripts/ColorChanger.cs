using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class ColorChanger : MonoBehaviour {


    private Color orange = new Color(1.0f, 0.64f, 0.0f);

    private Color purple = new Color (0.73f, 0f, 1f);

    private Color red = new Color(1f, 0.29f, 0.27f);

    private Color blue = new Color(0.28f, 0.65f, 1f);

    private Color yellow = new Color(1f, 0.98f, 0.52f);

    private Color green = new Color(0.52f, 1f, 0.54f);

    private Color[] color = new Color[6];

    private System.Random rnd = new System.Random();

    public bool canChange = false;

    public Camera cam;

    public int colorCount = -1;

	// Use this for initialization
	void Start () {
        color[0] = red;
        color[1] = yellow;
        color[2] = blue;
        color[3] = orange;
        color[4] = purple;
        color[5] = green;
        cam.backgroundColor = color[2];
        colorCount = 2;
    }

    // Update is called once per frame
    void Update () {
        if (canChange == true)
        {
            int num = rnd.Next(0, 6);
            cam.backgroundColor = color[num];
            colorCount = num;
            canChange = false;
        }
    }
}
