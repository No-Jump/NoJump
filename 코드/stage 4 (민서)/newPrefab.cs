using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPrefab : MonoBehaviour
{
    float timer;
    int waitingTime;
    private BoxCollider area;
    public GameObject gameObject;

    void Start()
    {
        area = GetComponent<BoxCollider>();
        timer = 0.0f;
        waitingTime = 5;
        area.enabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            Vector3 basePosition = transform.position;
            Vector3 size = area.size;
            float posX = basePosition.x + Random.Range(-size.x, size.x);
            Vector3 spawnPos = new Vector3(posX, 17, 0);
            Instantiate(gameObject);
            gameObject.transform.position = spawnPos;
            timer = 0;
        }
    }
}
