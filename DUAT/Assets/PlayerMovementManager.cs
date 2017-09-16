using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    /// <summary>
    /// Controls anything to do with the player moving
    /// </summary>

    public FormManager formManager;
    public PlayerInput playerInput;

    public float moveForce;
    public float jumpForce;

    private float dashTimer = 5f;

    private Vector2 currentPosition = new Vector2();

    public bool isGrounded = true;
    public bool isDashing = false;

    // Use this for initialization
    void Start ()
    {
 
	}
	
	// Update is called once per frame
	void Update ()
    {
        dashTimer -= Time.deltaTime;
        if (dashTimer <= 0)
        {
            isDashing = false;
            dashTimer = 5;
        }
        currentPosition = GetComponentInParent<Transform>().transform.position;
	}

   #region Movement Methods

    //Guess what this one does.
    public void MoveLeft()
    {
        this.transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveForce, this.transform.parent.GetComponent<Rigidbody2D>().velocity.y);
    }

    //Guess what THIS one does.
    public void MoveRight()
    {
        this.transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(moveForce, this.transform.parent.GetComponent<Rigidbody2D>().velocity.y);
    }

    //This one's rel tricky, bet you'll never guess what it does
    public void Jump()
    {
        if(isGrounded)
        {
            this.transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(this.transform.parent.GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    //Khepri movement ability
    public void Dash()
    {
        if(formManager.khepriForm && !isDashing)
        {
            Debug.Log("Dash!");
            isDashing = true;
        }
    }

#endregion
}
