using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Door : MonoBehaviour
{
    public GameObject Door;

    void Door_Open()
    {
        Door.SetActive(false);
        transform.Rotate(0, 0, 90);
    }

    void Door_Close()
    {
        GameObject.Find("Level_Door").transform.GetChild(0).gameObject.SetActive(true);
        transform.Rotate(0, 0, -90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Door.activeSelf == true)
            {
                Door_Open();
            }
            else
            {
                Door_Close();
            }
        }
    }
}
