using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite xSprite, oSprite;
    private Image image;
    private Button button;
    private Board board;
    private bool isChosen = false;
    public int row, col;
    private GameOver gameOver;
     
  

    private void Awake()
    {
      
        image = GetComponent <Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    private void Start()
    {
       // board = FindObjectOfType<Board>();
        board = FindFirstObjectByType<Board>();
        gameOver = FindFirstObjectByType<GameOver>();

    }
    
    private void OnClick()
    {
        Debug.Log($"Click: {gameObject.name} | ID: {GetInstanceID()} | isChosen: {isChosen}");
        if (isChosen )
        {
            Debug.Log("da chon");
            return;
        }

        changeImage(board.currentTurn);
        isChosen  = true;
        if (board.currentTurn == "x")
        {

            Debug.Log("x");
            board.currentTurn = "o";
            board.playerText.text = "O";
          
        }
        else
        {
            Debug.Log("o");
            board.currentTurn = "x";
            board.playerText.text = "X";

        }
        if (board.Checkwin(row, col))
        {
            Debug.Log("THANG");
            
            gameOver.game_over.SetActive(true);
           if(board.currentTurn == "o")
            {
                gameOver.setName("x");
                
            }
            else
            {
               
                gameOver.setName("o");
            }
        }

    }
    public void changeImage(string s)
    {
        if( s  == "x")
        {
            image.sprite = xSprite;
        }
        else
        {
            image.sprite = oSprite;
        }
    }
   
}
