using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    Rigidbody2D rbody;
    Player player;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player.level == 0)
            {
                rbody.mass = 100;
            }
            else
            {
                rbody.mass = 10;
            }
        }
    }

}
