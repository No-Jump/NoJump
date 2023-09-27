using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRail : MonoBehaviour
{
    public float Speed = 5;
    public float OffSetx = 1;


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.transform.Translate(Time.deltaTime * Speed * OffSetx, 0, 0);
        }
    }
}
