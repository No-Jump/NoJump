using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    Player player; // �÷��̾ �ٶ󺸰� �ִ� ����
    bool isActive = false; // Ȱ��ȭ ���¸� �����ϴ� ����.
    public string targetObjectName;



    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        // ���� �� ������Ʈ�� ��Ȱ��ȭ�մϴ�.
        //gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("flashlight"))
        {
            Debug.Log("SetActive(true) ȣ��");
            isActive = true; // ������Ʈ Ȱ��ȭ ���·� �����մϴ�.
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

        // ������Ʈ�� ��ġ ���ϱ�
        Vector3 mPosition = Input.mousePosition; // ���콺�� ��ġ (x, y)
        Vector3 oPosition = transform.position; // �÷��̾��� ��ġ
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition); // (x,y,z)
                                                                    // ���� ���ϱ�
        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;
        float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        // ȸ��
        this.transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);





    }

    
}