using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TopWiner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI topWinnerText;
    public List<int> winCounts = new List<int>();
    public List<string> playerNames = new List<string>();
    private void Checkupdate (string playerName)
    {
        bool playerFound = false;
        for(int i =0;i< playerNames.Count; i++)
        {
            if (playerNames[i] == playerName)
            {
                winCounts[i] += 1;
                playerFound = true;
                break;
            }
        }
        if (!playerFound)
        {
            playerNames.Add(playerName);
            winCounts.Add(1);
        }
    }


    void Start()
    {
        Load();
        if (GameOver.Player1Wins)
        {
            Checkupdate(StartGame.play_name_1);
        }else if(GameOver.Player2Wins)
        {
            Checkupdate(StartGame.play_name_2);
        }
        Save(); DisplayTop(); HightSort();
    }
    public void Load()
    {
        int playerCount = PlayerPrefs.GetInt("PlayerCount", 0);
        for(int i =0;i< playerCount; i++)
        {
            winCounts.Add(PlayerPrefs.GetInt("WinCounts" +i, 0));
            playerNames.Add(PlayerPrefs.GetString("PlayerNames" + i, "Player"));
        }
    }
    public void Save()
    {
        for(int i =0; i< winCounts.Count; i++)
        {
            PlayerPrefs.SetInt("WinCounts" + i, winCounts[i]);
            PlayerPrefs.SetString("PlayerNames" + i, playerNames[i]);

        }
        PlayerPrefs.SetInt("PlayerCount", winCounts.Count);
        PlayerPrefs.Save();
    }
    private void DisplayTop()
    {
        topWinnerText.text = "Top winner: \n";
        for(int i=0;i < playerNames.Count; i++)
        {
           if(i< 5)
            {
                topWinnerText.text += (i + 1) + ": " + playerNames[i] + " - " + winCounts[i] + "\n";
            }

        }
    }

    public void HightSort()
    {
        for(int i =0;i < winCounts.Count; i++)
        {
            for(int j =i+1;j< winCounts.Count; j++)
            {
                if (winCounts[i]< winCounts[j])
                {
                    int temp = winCounts[i];
                    winCounts[i] = winCounts[j];
                    winCounts[j] = temp;

                    string tempName = playerNames[i];
                    playerNames[i] = playerNames[j];
                    playerNames[j] = tempName;
                }

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
