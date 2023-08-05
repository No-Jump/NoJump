using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushbox : MonoBehaviour
{
    Rigidbody2D rbody;
    Player player;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player.level == 0)
            {
                rbody.mass = 150;
            }
            else if(player.level == 1)
            {
                rbody.mass = 15;
            }
            else if (player.level == 2)
            {
                rbody.mass = 10;
            }
            else if (player.level == 3)
            {
                rbody.mass = 2;
            }
            else if (player.level == 4)
            {
                rbody.mass = 1;
            }
        }
    }
}
