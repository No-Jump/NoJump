using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float weight;
    [SerializeField] Rigidbody2D rbody;


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Player.Instance.level == 0)
            {
                rbody.mass = 100;
            }
            else
            {
                rbody.mass = 10;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Btn"))
        {
            weight = 3;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Btn"))
        {
            weight = 0;
        }
    }
}
