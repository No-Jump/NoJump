using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRail : MonoBehaviour
{
    Player player;
    public float Speed = 5;
    public float OffSetx = 1;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.Translate(Time.deltaTime * Speed * OffSetx, 0, 0);
        }
    }
}
