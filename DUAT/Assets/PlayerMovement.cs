using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 currentPosition = this.transform.position;

		if(Input.GetKey(KeyCode.D))
        {
            this.transform.position = currentPosition + new Vector2(0.25f, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position = currentPosition + new Vector2(-0.25f, 0);
        }

    }
}
