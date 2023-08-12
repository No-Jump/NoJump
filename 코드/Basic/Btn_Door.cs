using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Door : MonoBehaviour
{
    Player player;
    Box box;
    public GameObject Door;
    public float Speed = 1;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        box = GameObject.FindWithTag("Box").GetComponent<Box>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            if(player.level + box.weight >= 3)
            {
                if (transform.localScale.y > 0.8)
                {
                    transform.localScale = new Vector3(2, transform.localScale.y - (Time.deltaTime * Speed), 1);
                }
            }
            
            if (player.level + box.weight >= 5)
            {
                if (transform.localScale.y > 0.5)
                {
                    transform.localScale = new Vector3(2, transform.localScale.y - (Time.deltaTime * Speed), 1);
                }
            }

            if (player.level + box.weight >= 7)
            {
                transform.localScale = new Vector3(2, transform.localScale.y - (Time.deltaTime * Speed), 1);
            }

            if (transform.localScale.y <= 0.1)
            {
                Door.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }
}
