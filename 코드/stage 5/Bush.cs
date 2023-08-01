using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    // ���� ����
    private GameObject bush;
    Player player;

    [SerializeField] private BoxCollider2D playerCollider;
    
    // player ���� �� ������ ����.
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        Player_Bush();
    }

    // �÷��̾ �ν���� �±׿� �浹���� �� �� ���� bush��� ���� ������Ʈ�� ����.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bush"))
        {
            bush = collision.gameObject;
        }
    }

    // �÷��̾ �ν��� �浹�ϰ� �������� �� �ʱ�ȭ
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bush"))
        {
            bush = null;
        }
    }

    // �ڷ�ƾ�� �̿��Ͽ� �ν��� �ڽ��ݶ��̴��� ������ ĳ���͸� ������ �ٽ� ��Ȱ��ȭ
    private IEnumerator DisableCollision()
    {
        BoxCollider2D bushCollider = bush.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, bushCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, bushCollider, false);
    }

    // �ڷ�ƾ �Լ� ������ ����
    void Player_Bush()
    {
        if (player.level > 2)
        {
            if (bush != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }
}
