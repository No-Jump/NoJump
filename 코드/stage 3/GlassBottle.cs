using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassBottle : MonoBehaviour
{
    private float horizontal;
    public float Speed = 2.0f;
    float PlayerSpeed = 8.0f;
    GameObject Bottlelock;
    GameObject Water;
    Player player;

    #region 유리병 HP
    private float BottleHp = 0;
    private float BottleMaxHp = 10;
    public GameObject BottleLife1;
    public GameObject BottleLife2;
    public GameObject BottleLife3;
    public GameObject BottleLife4;
    public GameObject BottleLife5;
    #endregion

    void Start()
    {
        BottleHp = BottleMaxHp;
        BottleLife1.GetComponent<Image>().enabled = false;
        BottleLife2.GetComponent<Image>().enabled = false;
        BottleLife3.GetComponent<Image>().enabled = false;
        BottleLife4.GetComponent<Image>().enabled = false;
        BottleLife5.GetComponent<Image>().enabled = false;

        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        Water = GameObject.FindWithTag("Water");
        Bottlelock = GameObject.Find("Glassbottle").transform.Find("lock").gameObject;
        Bottlelock.gameObject.SetActive(false);
        Water.gameObject.SetActive(false);
        
    }


    void Update()
    {
        BottleMovement();
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.enabled = false;
            Bottlelock.gameObject.SetActive(true);
            Water.gameObject.SetActive(true);

            if (Bottlelock.activeSelf == true)
            {
                BottleLife1.GetComponent<Image>().enabled = true;
                BottleLife2.GetComponent<Image>().enabled = true;
                BottleLife3.GetComponent<Image>().enabled = true;
                BottleLife4.GetComponent<Image>().enabled = true;
                BottleLife5.GetComponent<Image>().enabled = true;
            }
        }
    }
    
    void BottleMovement()
    {
       if (player.enabled == false)
       {
            horizontal = Input.GetAxisRaw("Horizontal");
            Vector3 pos = Vector3.right * horizontal;
            transform.Translate(pos.normalized * Speed * Time.deltaTime);

            player.transform.rotation = this.transform.rotation;
            player.transform.Translate(pos.normalized * PlayerSpeed * Time.deltaTime);
        }
    }

    public void DamageToBottle(int bottleDamage)
    {  
        BottleHp -= bottleDamage;

        if (BottleHp>6 && BottleHp <= 8)
        {
            BottleLife5.GetComponent<Image>().enabled = false;
        }

        else if (BottleHp>4 && BottleHp <= 6)
        {
            BottleLife5.GetComponent<Image>().enabled = false;
            BottleLife4.GetComponent<Image>().enabled = false;
        }

        else if (BottleHp>2 && BottleHp <= 4)
        {
            BottleLife5.GetComponent<Image>().enabled = false;
            BottleLife4.GetComponent<Image>().enabled = false;
            BottleLife3.GetComponent<Image>().enabled = false;
        }

        else if (BottleHp>0 && BottleHp <= 2)
        {
            BottleLife5.GetComponent<Image>().enabled = false;
            BottleLife4.GetComponent<Image>().enabled = false;
            BottleLife3.GetComponent<Image>().enabled = false;
            BottleLife2.GetComponent<Image>().enabled = false;
        }

        else if (BottleHp <= 0)
        {
            BottleLife5.GetComponent<Image>().enabled = false;
            BottleLife4.GetComponent<Image>().enabled = false;
            BottleLife3.GetComponent<Image>().enabled = false;
            BottleLife2.GetComponent<Image>().enabled = false;
            BottleLife1.GetComponent<Image>().enabled = false;
        }
    }
}
