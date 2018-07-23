using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour {

    Rigidbody2D rigidbody2D;

    public float maxHeight;
    public float jumpVerocity;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            Jump();
        }
	}
    void Jump()
    {
        rigidbody2D.velocity = new Vector2(0.0f, jumpVerocity);
    }
}
