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
            //if문에 플레이어 크기값 조건 추가해서 버튼 눌리는 유무 조건 추가 예정
            //에니메이션 구현은 없을 것 같음
        }
    }
}
