using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sow_count : MonoBehaviour
{
    

    void Update()
    {
        GetComponent<Text>().text = GameCounter.value.ToString();
    }

}
