using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBehavior : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    public float enemyDamage;
    public float enemyHealth;

    public GameObject droppedItem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Contains("Platform"))
        {
            moveSpeed *= -1;
        }

        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
            moveSpeed *= -1;
        }
    }

    private void FixedUpdate()
    {
        if(enemyHealth <= 0)
        {
            OnDeath();
        }
    }

    private void Update()
    {
        transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
    }

    public void TakeDamage(float amount)
    {
        enemyHealth -= amount;
    }

    private void OnDeath()
    {
        if(droppedItem != null)
        {
            Instantiate(droppedItem, transform.position, transform.rotation);
        }

        Destroy(this.gameObject);
    }
}
