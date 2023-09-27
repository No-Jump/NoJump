using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Door : MonoBehaviour
{
    Box box;
    public GameObject Door;
    public float Speed = 0.01f;
    public float btn_Weight;

    void Start()
    {
        box = GameObject.FindWithTag("Box").GetComponent<Box>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            if(Player.Instance.level + box.weight >= btn_Weight / 3)
            {
                if (transform.localScale.y > 0.8)
                {
                    //transform.localScale -= new Vector3(0,Speed, 0);
                    transform.localScale = new Vector3(2, transform.localScale.y - (Time.deltaTime * Speed), 1);
                }
            }
            
            if (Player.Instance.level + box.weight >= btn_Weight / 2)
            {
                if (transform.localScale.y > 0.5)
                {
                    //transform.localScale -= new Vector3(0,Speed, 0);
                    transform.localScale = new Vector3(2, transform.localScale.y - (Time.deltaTime * Speed), 1);
                }
            }

            if (Player.Instance.level + box.weight >= btn_Weight / 1)
            {
                //transform.localScale -= new Vector3(0,Speed, 0);
                transform.localScale = new Vector3(2, transform.localScale.y - (Time.deltaTime * Speed), 1);
            }

            if (transform.localScale.y <= 0.1)
            {
                Door.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }

    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(transform.localScale.y > 0.1)
        {
            transform.localScale = new Vector3(2, Time.deltaTime * Speed, 1);
        }
        else if(transform.localScale.y >= 1)
        {
            transform.localScale = new Vector3(2,1,1);
        }
    }
    */
}
