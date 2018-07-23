using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour {

    Rigidbody2D rigidbody2d;
    Animator animator;
    float angle;
    bool isDead = false;

    public float maxHeight;
    public float jumpVerocity;
    public float movingVelocityX;
    public GameObject bubbleSprite;
    bool isGround = false;

    public bool IsDead()
    {
        return isDead;
    } 

	// Use this for initialization
	void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
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
        if (isDead)
        {
            return;//ジャンプメソッドを抜ける   
        }
        isGround = false;

        rigidbody2d.velocity = new Vector2(0.0f, jumpVerocity);
    }
    void ReflectAngle()
    {
        float targetAngle;

        if (isDead)
        {
            targetAngle = 180.0f;
        }
        else
        {
            targetAngle = Mathf.Atan2(rigidbody2d.velocity.y, movingVelocityX) * Mathf.Rad2Deg;
        }

        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10.0f);
        bubbleSprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            if (isDead)
            {
                return;
            }
            animator.enabled = false;

            isDead = true;
        }
        else
        {
            isGround = true;
        }
    }
}
