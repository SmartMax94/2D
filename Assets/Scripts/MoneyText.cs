using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{

     public static int Coin;
     Text text;
   

     void Start()
    {
        text = GetComponent<Text>();
        Coin = PlayerPrefs.GetInt("coins", Coin);
        
        
    }
     void Update()
    {
        
        text.text = Coin.ToString();
       
    }
}
