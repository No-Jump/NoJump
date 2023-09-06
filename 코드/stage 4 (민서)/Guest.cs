using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
    public GameObject guest;
    public GameObject hand;
    Player player;
    public GameObject targetObject;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        SpawnGuest();
    }
    void SpawnGuest()
    {
        int result = Random.Range(3, 6);
        iTween.MoveTo(guest, iTween.Hash("position", new Vector3(-11.2f, 4.3f, 0), "delay", 3,
            "time", 3, "easeType", iTween.EaseType.easeOutCirc, "oncomplete", "GuestComeback"));
    }
    private void GuestComeback()
    {
        int result = Random.Range(3, 6);
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(-11.2f, 19.7f, 0), "delay", result,
            "time", 3, "easeType", iTween.EaseType.easeOutCirc, "oncomplete", "SpawnGuest"));
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Spawnhand();
        }
    }
    void Spawnhand ()
    {
        Vector3 dir = targetObject.transform.position;
        dir.y += 2;
        iTween.MoveTo(hand, iTween.Hash("position", dir,
            "time",1, "easeType", iTween.EaseType.easeInSine));
    }
}
