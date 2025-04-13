using UnityEngine;

public class Coins : MonoBehaviour
{
    public AudioClip audioClip;
    private GameObject player;
    private AudioSource audioSource;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D (Collider2D collision)
    {
        
      if (collision.CompareTag  ("Player"))
        {


            MoneyText.Coin += 1;
            audioSource.Play();
            PlayerPrefs.SetInt("coins", MoneyText.Coin);
            audioSource.PlayOneShot(audioClip);
            Destroy(gameObject);
        }
    }

}

