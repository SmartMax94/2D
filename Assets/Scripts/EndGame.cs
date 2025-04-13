using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject Panelwin;//

    
    private  void OnTriggerEnter2D (Collider2D collision)
    {
       if (collision.tag == "Player") {
           SceneManager.LoadScene("EndGame");
            
        }
        }
    }

