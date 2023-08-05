using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class newPrefab : MonoBehaviour
{
    private BoxCollider area;
    public GameObject gameObject;

    void Start()
    {
        area = GetComponent<BoxCollider>();
        area.enabled = false;
        Invoke("New", 3f);
    }
    void New()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;
        float posX = basePosition.x + Random.Range(-size.x, size.x);
        Vector3 spawnPos = new Vector3(posX, 17, 0);
        Instantiate(gameObject);
        gameObject.transform.position = spawnPos;
        Start();
    }
}
