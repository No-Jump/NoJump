using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverDa : MonoBehaviour
{
    int ReDash = 1;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.RecoverDash(ReDash);
            this.gameObject.SetActive(false);
        }
    }
}
