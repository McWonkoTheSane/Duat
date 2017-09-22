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

    public LayerMask playerMask;

    public float moveForce;
    public float jumpForce;
    public float dashForce;

    private bool canDoubleJump = false;

    public int numJumps = 0;

    private float dashTimer = 5f;

    //This will be synced to the animation later
    private float placeholderDashDuration = 1f;

    private Vector2 currentPosition = new Vector2();
    private Vector2 moveVelocity;

    public bool isGrounded = true;
    public bool dashUsed = false;
    public bool isDashing = false;

    private Transform tagGround;

    private Rigidbody2D playerRigidbody;

    // Use this for initialization
    void Start ()
    {
        playerRigidbody = this.transform.parent.GetComponent<Rigidbody2D>();
        tagGround = GameObject.Find(playerRigidbody.gameObject.name + "/tag_ground").transform;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(currentPosition, tagGround.position, playerMask);
        if(isGrounded)
        {
            numJumps = 0;
        }
        Move(Input.GetAxis("Horizontal"));
    }

    // Update is called once per frame
    void Update ()
    {
        //Again, all of this is placeholder since I don't have animations to work with right now
        if(isDashing)
        {
            placeholderDashDuration -= Time.deltaTime;
        }
        if(placeholderDashDuration < 0)
        {
            isDashing = false;
            placeholderDashDuration = 1f;
        }
        //End placeholder section

        if(dashUsed)
        {
            dashTimer -= Time.deltaTime;
        }

        if (dashTimer <= 0)
        {
            dashUsed = false;
            dashTimer = 5f;
        }

        currentPosition = GetComponentInParent<Transform>().transform.position;
	}

    #region Movement Methods

    //Move
    public void Move(float horizInput)
    {
        if(!isDashing)
        {
            moveVelocity = playerRigidbody.velocity;
            moveVelocity.x = horizInput * moveForce;

            playerRigidbody.velocity = moveVelocity;
        }
    }

    //This one's real tricky, bet you'll never guess what it does
    public void Jump()
    {
        if (isGrounded)
        {
            numJumps = 0;
            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            canDoubleJump = true;
        }
        else
        {
            if (formManager.raForm && canDoubleJump)
            {
                canDoubleJump = false;
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0);
                playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    //Khepri movement ability
    public void Dash(float horizInput)
    {
        if(formManager.khepriForm && !dashUsed)
        {
            isDashing = true;
            Debug.Log("Dash");
            horizInput = Mathf.Round(horizInput);
            playerRigidbody.velocity = new Vector2(horizInput * dashForce, 0);
            dashUsed = true;
        }
    }


#endregion
}
