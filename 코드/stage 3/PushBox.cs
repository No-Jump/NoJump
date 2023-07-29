using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    Rigidbody2D rbody;
    //PhysicsMaterial2D material;
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
                rbody.mass = 100;
                //material.friction = 100;
            }
            else
            {
                rbody.mass = 10;
                //material.friction = 5;
            }
        }
    }

}
