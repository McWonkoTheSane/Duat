using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{ 
    /// <summary>
    /// Master input manager 
    /// </summary>

    public PlayerMovementManager movementManager;
    public FormManager formManager;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.D))
        {
            movementManager.MoveRight();
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementManager.MoveLeft();
        }
        if(Input.GetKey(KeyCode.Space))
        {
            movementManager.Jump();
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            movementManager.Dash();
        }
        if(Input.GetKey(KeyCode.Alpha1) && !formManager.khepriForm)
        {
            formManager.ChangeForm("Khepri");
        }
        if (Input.GetKey(KeyCode.Alpha2) && !formManager.khnumForm)
        {
            formManager.ChangeForm("Khnum");
        }
        if (Input.GetKey(KeyCode.Alpha3) && !formManager.raForm)
        {
            formManager.ChangeForm("Ra");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            movementManager.isGrounded = true;
        }
    }
}
