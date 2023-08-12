using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float weight = 3;
    [SerializeField] Rigidbody2D rbody;
    Player player;

    void Start()
    {
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
