using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearPrefab : MonoBehaviour
{
    public int damage = 1;

    GlassBottle bottle;
    Player player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        bottle = GameObject.FindWithTag("GlassBottle").GetComponent<GlassBottle>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GlassBottle")
        {
            bottle.DamageToBottle(damage);
            Destroy(this.gameObject);
        }

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
