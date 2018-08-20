using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    
    public static int Lives = 20;
    public static int money = 20;
    public Text moneyText;
    public Text livesText;

   void start()
    {
        Lives = 20;
        money = 20;
        moneyText.text = money.ToString();
        livesText.text = Lives.ToString();
    }

    public void LoseLife(int l = 1)
    {
        Enemy.numberOfEnemies--;
        Lives -= l;
        if (Lives <= 0)
        {
            
            Time.timeScale = 0f;
        }
    }

    void Update()
    {
        Debug.Log(Enemy.numberOfEnemies);
        moneyText.text = "Money: $" + money.ToString();
        livesText.text = "Lives: " + Lives.ToString();
    }

    
}
