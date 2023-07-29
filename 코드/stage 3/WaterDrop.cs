using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public GameObject[] prefabs; //찍어낼 게임 오브젝트(물방울)
    public float intervalSec = 2f;
    public int count = 100;
    private List<GameObject> gameObject = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("Spawn", intervalSec, intervalSec);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 area = GetComponent<SpriteRenderer>().bounds.size;
        Vector3 newPos = this.transform.position;

        float posX = newPos.x + Random.Range(-area.x / 2f, area.x / 2f);
        float posY = newPos.y + Random.Range(-area.y / 2f, area.y / 2f);
        float posZ = -5;

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }

    private void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length);

        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        GameObject newGameObject = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        gameObject.Add(newGameObject);  //gameObject 리스트에 newGameObject 추가
    }
}
