using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class des_chandelier : MonoBehaviour
{
    public float Speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    float randomX, randomY;
    int damage = 1;

    private void Start()
    {
        randomX = Random.Range(-1f,1f);
        randomY = Random.Range(0f, 1f);

        Vector2 dir = new Vector2(randomX, randomY).normalized;

        rb.AddForce(dir * Speed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
