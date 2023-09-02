using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteRose : MonoBehaviour
{
    public int damage = 1;
    public float damageTime = 0.5f;
    public float damagecoolTime = 0;

    private void Update()
    {
        damagecoolTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Player.Instance.level == 0|| Player.Instance.level == 1)
            {
                Player.Instance.TakeDamage(damage);
            }
        }
    }
}

