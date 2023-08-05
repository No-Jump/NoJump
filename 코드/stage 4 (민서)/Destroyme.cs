using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyme : MonoBehaviour
{
    public bool isOutsideCamera = true;
    public string mainCameraTag = "MainCamera";

    void Update()
    {
        // 오브젝트가 Main Camera 밖으로 나갔는지 확인
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 pos = mainCamera.GetComponent<Camera>().WorldToScreenPoint(this.gameObject.transform.position);
        if (pos.x > 0 || pos.x < 1 || pos.y > 0 || pos.y < 1)
        {
            isOutsideCamera = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 떨어진 후에 Main Camera 밖으로 나간 경우 삭제
        if (isOutsideCamera)
        {
            Destroy(this.gameObject);
        }
    }
}

