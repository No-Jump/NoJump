using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public string targetObjectName;
    public int demage = 1;
    private Player player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == targetObjectName)
        {
            player.TakeDamage(demage);
        }
    }
}
