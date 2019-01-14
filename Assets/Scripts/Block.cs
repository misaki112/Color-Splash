using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    private Rigidbody2D rb;

    public float moveSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 5f);
        rb.velocity = new Vector2(0, -moveSpeed);
    }
}
