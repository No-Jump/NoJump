using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearPrefab : MonoBehaviour
{
    public int damage = 1;

    Player player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
