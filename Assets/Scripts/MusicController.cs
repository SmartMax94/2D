using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private  static MusicController instance;
   private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
     

    
        
    }
}
