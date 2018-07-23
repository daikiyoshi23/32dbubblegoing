using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour {

    Rigidbody2D rigidbody2D;
    Animator animator;
    float angle;

    public float maxHeight;
    public float jumpVerocity;
    public float movingVelocityX;
    public GameObject bubbleSprite;
    bool isGround = false;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = bubbleSprite.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            Jump();
        }

        ReflectAngle();
        animator.SetBool("isGround", isGround);

        
	}

    void Jump()
    {
        rigidbody2D.velocity = new Vector2(0.0f, jumpVerocity);
    }
    void ReflectAngle()
    {
        float targetAngle = Mathf.Atan2(rigidbody2D.velocity.y, movingVelocityX) * Mathf.Rad2Deg;
        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10.0f);
        bubbleSprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }
}
