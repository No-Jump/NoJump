using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public AudioClip audioDamage;
    public AudioClip audioItem;
    public AudioClip audioDash;
    public AudioClip audioReHp;
    public AudioClip audioCoin;
    public AudioClip audioLevelUp;
    public AudioClip audioLevelDown;

    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            //씬 전환되도 유지되도록
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlaySound(string action)
    {
        switch(action)
        {
            case "Damage":
                audioSource.clip = audioDamage;
                break;
            case "Item":
                audioSource.clip = audioItem;
                break;
            case "Dash":
                audioSource.clip = audioDash;
                break;
            case "ReHp":
                audioSource.clip = audioReHp;
                break;
            case "Coin":
                audioSource.clip = audioCoin;
                break;
            case "levelUp":
                audioSource.clip = audioLevelUp;
                break;
            case "levelDown":
                audioSource.clip = audioLevelDown;
                break;
        }
        audioSource.Play();
    }
}
