using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rose : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    int i = 0;
    int damage = 3;
    public Sprite[] Rose = new Sprite[3];


    private void Start()
    {
        StartCoroutine(Change_sec());
    }

    IEnumerator Change_sec()
    {
        for(i = 0; i <= Rose.Length; i++) 
        {
            if(i == 3)
            {
                i = 0;
                sprite.sprite = Rose[i];
                yield return new WaitForSecondsRealtime(3f);
            }
            else
            {
                sprite.sprite = Rose[i];
                yield return new WaitForSecondsRealtime(3f);
            }
        }
        
    }
    /*
    void Change_Rose(int num)
    {
        if(num == 0)
        {
            sprite.sprite = Rose[num];
        }
        else if(num == 1)
        {
            sprite.sprite = Rose[num];
        }
        else if(num == 2)
        {
            sprite.sprite = Rose[num];
            num = 0;
        }
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (sprite.sprite == Rose[2])
            {
                Player.Instance.TakeDamage(damage);
            }
        }
    }
}
