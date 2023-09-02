using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    Player player; // 플레이어가 바라보고 있는 방향
    bool isActive = false; // 활성화 상태를 관리하는 변수.
    public string targetObjectName;



    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        // 시작 시 오브젝트를 비활성화합니다.
        //gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("flashlight"))
        {
            Debug.Log("SetActive(true) 호출");
            isActive = true; // 오브젝트 활성화 상태로 변경합니다.
            gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (isActive)
        {
            return;
        }

        this.transform.position = player.transform.position;

        // 오브젝트의 위치 구하기
        Vector3 mPosition = Input.mousePosition; // 마우스의 위치 (x, y)
        Vector3 oPosition = transform.position; // 플레이어의 위치
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition); // (x,y,z)
                                                                    // 각도 구하기
        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;
        float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        // 회전
        this.transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);





    }

    
}