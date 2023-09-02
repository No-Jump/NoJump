using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverHp : MonoBehaviour
{
    public int Heal = 1;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.RecoverHp(Heal);
            this.gameObject.SetActive(false);
        }
    }
}

