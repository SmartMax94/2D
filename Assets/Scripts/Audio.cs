using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private static Audio instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

       

       
    }
}
