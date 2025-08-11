using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public TMP_InputField playerInput1, PlayerInput2;
    public static string play_name_1, play_name_2;
    private void Update()
    {
        play_name_1 = playerInput1.text;
        play_name_2 = PlayerInput2.text;
    }
    public void playGame()
    {
        if(play_name_1 != play_name_2)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
