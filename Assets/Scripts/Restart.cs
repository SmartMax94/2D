using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    

   public  void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
