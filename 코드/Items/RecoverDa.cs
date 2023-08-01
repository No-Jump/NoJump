using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverDa : MonoBehaviour
{
    int ReDash = 1;

    Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.RecoverDash(ReDash);
            this.gameObject.SetActive(false);
        }
    }
}
