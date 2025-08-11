using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject cellPretabs;
    public Transform board;
    public GridLayoutGroup gridLayout;
    public int boardSize;
    public string currentTurn = "o";
    private string[,] matrix;
    public TextMeshProUGUI playerText;
 
    void Start()
    {
        matrix = new string[boardSize + 1, boardSize + 1];
        gridLayout.constraintCount = boardSize;
        CreateBoard();
    }

    // Update is called once per frame
   private void CreateBoard()
    {
        for( int i = 1; i <= boardSize; i++)
        {
            for(int j = 1;j <= boardSize; j++)
            {
             Cell cell=   Instantiate(cellPretabs, board).GetComponent<Cell>();
                cell.row = i;
                cell.col = j;
                matrix[i, j] = "";
            }
        }
    }
    public bool Checkwin(int row, int col)
    {
        matrix[row, col] = currentTurn;
        int count = 0;
        //hang doc
        for( int i =row -1;i >= 1; i--)
        {
            if (matrix[i, col] == currentTurn) { count++; } else { break; }
        }
         
        for (int i = row + 1; i <= boardSize; i++)
        {
            if (matrix[i, col] == currentTurn) { count++; } else { break; }
        }
        if (count + 1 >= 5)
        {
            return true;
        }

        count = 0;
        //hang ngang
        for (int i = col - 1; i >= 1; i--)
        {
            if (matrix[row,i] == currentTurn) { count++; } else { break; }
        }
        for (int i = col + 1; i <= boardSize; i++)
        {
            if (matrix[row,i] == currentTurn) { count++; } else { break; }
        }
        if (count + 1 >= 5)
        {
            return true;
        }
        //hang cheo thu 1
        count = 0;

        for (int i = 1;row- i >= 1; i++)
        {
            if (matrix[row -i,col- i] == currentTurn) { count++; } else { break; }
        }
        for (int i =   1;row+ i <= boardSize && col +i <= boardSize; i++)
        {
            if (matrix[row+i,col+ i] == currentTurn) { count++; } else { break; }
        }
 
        if (count+1 >= 5)
        {
            return true;
        }

        //hang cheo thu 2
        count = 0;
        for (int i = 1; row - i >= 1 && col + i<= boardSize; i++)
        {
            if (matrix[row - i, col + i] == currentTurn) { count++; } else { break; }
        }
        for (int i = 1; row + i <= boardSize && col -i >= 1; i++)
        {
            if (matrix[row + i, col - i] == currentTurn) { count++; } else { break; }
        }

        if (count + 1 >= 5)
        {
            return true;
        }

        return false;
    }
}
