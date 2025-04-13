using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour
{
    public GameObject Player;
    
    void Awake ()
    {
        GameObject START_POSITION = GameObject.FindGameObjectWithTag("START_POSITION") as GameObject;
        Player = GameObject.FindGameObjectWithTag("Player") as GameObject;
        
        if (START_POSITION !=null && Player !=null)
        {
            Player.transform.position = START_POSITION.transform.position;
            Player.transform.rotation = START_POSITION.transform.rotation;        
        } 
   
        
    }
}
