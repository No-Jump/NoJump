using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{ 
    Player player;
    int damage = 5;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(damage);
        }
    }
}
