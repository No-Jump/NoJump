using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transparency : MonoBehaviour
{
    Color color;
    public GameObject transparency;
    void Start()
    {
        color = transparency.GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            color.a = 0.5f;
            transparency.GetComponent<SpriteRenderer>().color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            color.a = 1f;
            transform.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
