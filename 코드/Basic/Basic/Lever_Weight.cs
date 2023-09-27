using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Weight : MonoBehaviour
{
    public GameObject Door;
    public float weight;
    private bool key = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            key = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            key = false;
        }
    }

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
                if (Player.Instance.level > weight && key)
                {
                    Door_Open();
                }
                //transform.Rotate(0, 0, 90);
            }
            else
            {
                Door_Close();
                //transform.Rotate(0, 0, -90);
            }
        }
    }
}
