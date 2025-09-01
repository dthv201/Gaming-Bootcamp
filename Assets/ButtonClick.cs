using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonClick : MonoBehaviour
{
    public TMP_Text buttonText1;
    public TMP_Text buttonText2;
    public TMP_Text buttonText3;
    public TMP_Text buttonText4;
    public TMP_Text buttonText5;
    public TMP_Text buttonText6;
    public TMP_Text buttonText7;
    public TMP_Text buttonText8;
    public TMP_Text buttonText9;

    public TMP_Text label;
    public GameObject resetButton;

    private TMP_Text[,] board;
    private string turn = "X";
    private bool gameOver = false;

    void Start()
    {
        board = new TMP_Text[,] {
            { buttonText1, buttonText2, buttonText3 },
            { buttonText4, buttonText5, buttonText6 },
            { buttonText7, buttonText8, buttonText9 }
        };

        label.text = "X turn";
        resetButton.SetActive(false);
    }

    public void ButtonOnClick(TMP_Text buttonText)
    {
        if (gameOver) return;

        string cleanedText = buttonText.text.Trim();
        if (string.IsNullOrEmpty(cleanedText) && turn == "X")
        {
            buttonText.text = turn;
            if (CheckEnd()) return;

            ChangeTurn();
            StartCoroutine(AIMoveWithDelay(0.5f)); 
        }
    }

    private IEnumerator AIMoveWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AIMove();
    }

    private void AIMove()
    {
        if (gameOver) return;

        List<TMP_Text> emptyCells = new List<TMP_Text>();
        foreach (var cell in board)
        {
            if (string.IsNullOrEmpty(cell.text.Trim()))
                emptyCells.Add(cell);
        }

        if (emptyCells.Count > 0)
        {
            int randIndex = Random.Range(0, emptyCells.Count);
            TMP_Text chosenCell = emptyCells[randIndex];
            chosenCell.text = "O";

            if (CheckEnd()) return;

            ChangeTurn();
        }
    }

    private bool CheckEnd()
    {
        if (CheckForWin(board))
        {
            label.text = turn + " won!";
            gameOver = true;
            resetButton.SetActive(true);
            return true;
        }
        else if (CheckForFull(board))
        {
            label.text = "It's a tie!";
            gameOver = true;
            resetButton.SetActive(true);
            return true;
        }
        return false;
    }

    private void ChangeTurn()
    {
        turn = (turn == "X") ? "O" : "X";
        label.text = turn + " turn";
    }

    private bool CheckForWin(TMP_Text[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0].text == board[i, 1].text &&
                board[i, 1].text == board[i, 2].text &&
                !string.IsNullOrEmpty(board[i, 0].text))
                return true;

            if (board[0, i].text == board[1, i].text &&
               board[1, i].text == board[2, i].text &&
               !string.IsNullOrEmpty(board[0, i].text))
                return true;
        }

        if (board[0, 0].text == board[1, 1].text &&
            board[1, 1].text == board[2, 2].text &&
            !string.IsNullOrEmpty(board[0, 0].text))
            return true;

        if (board[0, 2].text == board[1, 1].text &&
            board[1, 1].text == board[2, 0].text &&
            !string.IsNullOrEmpty(board[0, 2].text))
            return true;

        return false;
    }

    private bool CheckForFull(TMP_Text[,] board)
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (string.IsNullOrEmpty(board[i, j].text.Trim()))
                    return false;

        return true;
    }

    public void ResetGame()
    {
        foreach (var cell in board)
        {
            cell.text = "";
        }

        turn = "X";
        gameOver = false;
        label.text = "X turn";
        resetButton.SetActive(false);
    }
}
