using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyme : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}

