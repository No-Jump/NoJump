using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class newPrefab : MonoBehaviour
{
    public bool enableSpawn = true;

    //Prefab을 받을 public 변수
    public GameObject Sugar;


    // 생성된 객체를 받아올 배열
    public GameObject[] Sugars;
    private BoxCollider area;
    public GameObject gameObject;

    void Start()
    {
        area = GetComponent<BoxCollider>();
        area.enabled = false;

        InvokeRepeating("SpawnSugar", 3, 3);
    }
    void SpawnSugar()
    {
        if (enableSpawn)
        {
            // Prefub의 태그를 이용해서 적 갯수 찾아오기
            Sugars = GameObject.FindGameObjectsWithTag("sugar");
            if (Sugars.Length < 5)
            {
                Vector3 basePosition = transform.position;
                Vector3 size = area.size;
                float posX = basePosition.x + Random.Range(-size.x, size.x);
                Vector3 spawnPos = new Vector3(posX, 17, 0);
                Instantiate(gameObject);
                gameObject.transform.position = spawnPos;
            }

        }
    }
}
