using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBehavior : MonoBehaviour
{
    [SerializeField] private float enemyDamage;
    private int currentDirection;
    private Rigidbody2D myBody;

    [SerializeField] private float moveForce;

	// Use this for initialization
	void Start ()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        //0 is right, 1 is left
        currentDirection = Random.Range(0, 2);
	}

    // Update is called once per frame
    void Update ()
    {
        Debug.Log(currentDirection);
        Move(currentDirection);
    }

    private void Move(int direction)
    {
        if(direction == 0)
        {
            myBody.velocity = new Vector2(moveForce, 0);
        }
        else
        {
            Debug.Log("Attempting to move left");
            myBody.velocity = new Vector2(-moveForce, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the collidiong object is a player, They take damage
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
        }
        if(collision.gameObject.layer.Equals("Environment"))
        {
            if(currentDirection == 1)
            {
                currentDirection = 0;
            }
            else
            {
                Debug.Log("Swapping to move left");
                currentDirection = 1;
            }
        }
    }
}
