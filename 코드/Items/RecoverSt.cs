using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverSt : MonoBehaviour
{
    int StHeal = 10;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.RecoverSt(StHeal);
            this.gameObject.SetActive(false);
        }
    }
}
