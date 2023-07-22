using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRose : MonoBehaviour
{
    public int damage = 1;
    public float damageTime = 0.5f;
    public float damagecoolTime = 0;

    Player player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        damagecoolTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (player.level == 3 || player.level == 4)
            {
                player.TakeDamage(damage);
            }
        }
    }
}
