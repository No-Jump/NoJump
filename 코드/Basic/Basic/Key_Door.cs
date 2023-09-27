using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Key_Door : MonoBehaviour
{
    public GameObject Door;
    private float Speed = 5;
    public float MaxY;
    private float OffsetY;


    void Open_Door()
    {
        OffsetY = Door.gameObject.transform.position.y;
        if(OffsetY < MaxY )
        {
            Door.transform.Translate(0, Speed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Door.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

}
