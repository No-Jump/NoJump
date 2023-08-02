using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public GameObject[] prefabs; //찍어낼 게임 오브젝트
    public float intervalSec = 2f;
    public int count = 100;

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
        int random = Random.Range(0, 10);

        Vector3 spawnPos = GetRandomPosition(); //랜덤위치함수

        switch (random)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                Instantiate(prefabs[0], spawnPos, Quaternion.identity);
                Debug.Log("Prefab[0]");
                break;
            case 4:
            case 5:
                Instantiate(prefabs[1], spawnPos, Quaternion.identity);
                Debug.Log("Prefab[1]");
                break;
            case 6:
            case 7:
                Instantiate(prefabs[2], spawnPos, Quaternion.identity);
                Debug.Log("Prefab[2]");
                break;
            case 8:
                Instantiate(prefabs[3], spawnPos, Quaternion.identity);
                Debug.Log("Prefab[3]");
                break;
            case 9:
                Instantiate(prefabs[4], spawnPos, Quaternion.identity);
                Debug.Log("Prefab[4]");
                break;
            default:
                break;

        }

    }

}
