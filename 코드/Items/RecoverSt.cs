using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverSt : MonoBehaviour
{
    int StHeal = 10;

    Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.RecoverSt(StHeal);
            this.gameObject.SetActive(false);
        }
    }
}
