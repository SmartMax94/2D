using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
     public int level;
     public Text levelText;
    public Button[] levels;
    
   
    void Start()
    {
        
        levelText.text = level.ToString();
    } 
    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + level.ToString());
        Destroy(GameObject.Find("Audio Source"));
    }

    public void Select(int numberInBuild)
    {
        SceneManager.LoadScene(numberInBuild);
        Destroy(GameObject.Find("Audio Source"));
    }
}
