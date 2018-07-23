using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjects : MonoBehaviour {

    public float speed;
    public float startPosition;
    public float endPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        if(transform.position.x <= endPosition)
        {
            ScrollEnd ();
        }
	}

    void ScrollEnd()
    {
        transform.Translate(-1 * (endPosition - startPosition), 0, 0);
    }
}
