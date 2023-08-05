using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCounter : MonoBehaviour
{
    public static int value;
    private int startCount = 0;

    void Start()
    {
        value = startCount;
    }


}
