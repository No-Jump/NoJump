using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    // 변수 설정
    private GameObject bush;

    [SerializeField] private BoxCollider2D playerCollider;
    
    // player 변수 값 설정을 위함.

    private void Update()
    {
        Player_Bush();
    }

    // 플레이어가 부쉬라는 태그와 충돌했을 때 그 블럭을 bush라는 게임 오브젝트로 설정.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bush"))
        {
            bush = collision.gameObject;
        }
    }

    // 플레이어가 부쉬와 충돌하고 빠져나온 뒤 초기화
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bush"))
        {
            bush = null;
        }
    }

    // 코루틴을 이용하여 부쉬의 박스콜라이더를 무시해 캐릭터를 떨구고 다시 비활성화
    private IEnumerator DisableCollision()
    {
        PolygonCollider2D bushCollider = bush.GetComponent<PolygonCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, bushCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, bushCollider, false);
    }

    // 코루틴 함수 시작의 조건
    void Player_Bush()
    {
        if (Player.Instance.level > 2)
        {
            if (bush != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }
}
