using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject game_over;
    public TextMeshProUGUI winerText;
    public void setName(string s)
    {
        winerText.text = s + " th?ng!";
    }
    public void playAgain()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
