using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    [SerializeField] float delay = 1f;

    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   private void Start()
    {
        Time.timeScale = 0;
        StartCoroutine("gameOver"); 
    }
}
