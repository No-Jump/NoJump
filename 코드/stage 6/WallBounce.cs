using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    float Speed = 1000f;
    [SerializeField] private Rigidbody2D rb;
    float randomX, randomY;
    int count = 0;
    int damage = 1;

    private void Start()
    {
        randomX = Random.Range(-1f, 1f);
        randomY = Random.Range(-1f, 1f);

        Vector2 dir = new Vector2(randomX, randomY).normalized;

        rb.AddForce(dir*Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        count++;
        if(count == 10) 
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
