using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyme : MonoBehaviour
{
    public bool isOutsideCamera = true;
    public string mainCameraTag = "MainCamera";

    void Update()
    {
        // ������Ʈ�� Main Camera ������ �������� Ȯ��
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 pos = mainCamera.GetComponent<Camera>().WorldToScreenPoint(this.gameObject.transform.position);
        if (pos.x > 0 || pos.x < 1 || pos.y > 0 || pos.y < 1)
        {
            isOutsideCamera = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ������ �Ŀ� Main Camera ������ ���� ��� ����
        if (isOutsideCamera)
        {
            Destroy(this.gameObject);
        }
    }
}

