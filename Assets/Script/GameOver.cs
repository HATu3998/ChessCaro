using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject game_over;
    public TextMeshProUGUI winerText;
    public static bool Player1Wins, Player2Wins;
    public void setName(string s)
    {
      if(s == "x")
        {
            winerText.text = StartGame.play_name_2 + " Winner";
            Player1Wins =false;
            Player2Wins = true;
            
        }
        else
        {
            winerText.text = StartGame.play_name_1 + " Winner";
            Player1Wins = true;
            Player2Wins = false;


        }
    }
    
    public void playAgain()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
