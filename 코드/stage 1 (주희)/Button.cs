using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public string PlayerName;
    public float speed = 0;
    public int lastcnt = 3;
    private Player player;

    private void Start()
    {
        GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == PlayerName)
        {
            speed = 1;
        }  
    }

    void Update()
    {
        if(this.transform.position.y >= -187 && speed == 1 && player.level >= 2 && GameCounter.value >= lastcnt)  
        {
            this.transform.Translate(0, -speed / 50, 0); 
            //if���� �÷��̾� ũ�Ⱚ ���� �߰��ؼ� ��ư ������ ���� ���� �߰� ����
            //���ϸ��̼� ������ ���� �� ����
        }
    }
}
