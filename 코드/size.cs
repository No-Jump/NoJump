using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class size : MonoBehaviour
{
    public Transform njh;
    // Start is called before the first frame update
    void Start()
    {
        njh.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);   // 크기 조정
        njh.transform.position = new Vector3(-2.68f, 0.42f, 0f);    // 위치 조정
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
