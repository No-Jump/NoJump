using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverHp : MonoBehaviour
{
    int Heal = 1;

    Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.RecoverHp(Heal);
            this.gameObject.SetActive(false);
        }
    }
}
