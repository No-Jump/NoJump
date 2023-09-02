using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chandelier : MonoBehaviour
{
    Rigidbody2D rbody;
    int damage = 10;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

        iTween.RotateTo(this.gameObject, iTween.Hash("z", 6f,
                                                   "time", 0.8f,
                                                   "looptype",iTween.LoopType.pingPong,
                                                   "easetype",iTween.EaseType.linear,
                                                   "name","chandelier",
                                                   "ignoretimescale",true
                                                   )
            );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rbody.isKinematic = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.TakeDamage(damage);
        }
        
        if (collision.gameObject.CompareTag("Map"))
        {
            damage = 0;
            rbody.isKinematic = true;
            iTween.StopByName("chandelier");
        }
    }
}
