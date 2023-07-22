using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public string PlayerName;
    public float speed = 1;

    private void Start()
    {
        GetComponent<Rigidbody2D>();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == PlayerName)
        {
            speed = -1;
        }  
    }

    void Update()
    {
        if(this.transform.position.y >= -29.34 && speed == -1)  
        {
            this.transform.Translate(0, speed / 50, 0); 
            //if문에 플레이어 크기값 조건 추가해서 버튼 눌리는 유무 조건 추가 예정
            //에니메이션 구현은 없을 것 같음
        }
    }
}
