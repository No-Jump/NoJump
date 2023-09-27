using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chandelier : MonoBehaviour
{
    [SerializeField] Rigidbody2D rbody;
    [SerializeField] Particle particle;
    public GameObject des_json;
    float offsetX = 0f, offsetY = 0.5f;
    int damage = 10, count = 0;

    void Start()
    {
         iTween.RotateTo(this.gameObject, iTween.Hash("z", 10f,
                                                   "time", 0.8f,
                                                   "looptype",iTween.LoopType.pingPong,
                                                   "easetype",iTween.EaseType.easeInOutSine,
                                                   "name","chandelier",
                                                   "ignoretimescale",true
                                                   )
            );
    }
    
    public void Create_desjson()
    {
        Vector3 newPos = this.transform.position;
        newPos.y += offsetY;
        newPos.x += offsetX;
        newPos.z = -5f;
        for (int i = 0; i < 5; i++)
        {
            GameObject newGameObject = Instantiate(des_json) as GameObject;
            newGameObject.transform.position = newPos;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            iTween.StopByName("chandelier");
            rbody.isKinematic = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.TakeDamage(damage);
        }
        
        if (collision.gameObject.CompareTag("Map"))
        {
            damage = 0;
            rbody.isKinematic = true;
            rbody.mass = 100;
            if(count == 0)
            {
                particle.StartParticleSystems(0,4);
                Create_desjson();
                count = 1;
            }
        }
    }
}
