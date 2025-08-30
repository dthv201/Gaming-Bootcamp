using System;
using TMPro;
using UnityEngine;

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
    private TMP_Text[,] board;
    private string turn = "X";

    void Start()
    {   
        board = new TMP_Text[,] {
            { buttonText1, buttonText2, buttonText3 },
            { buttonText4, buttonText5, buttonText6 },
            { buttonText7, buttonText8, buttonText9 }
        };

        label.text = "X turn";
    }

    public void ButtonOnClick(TMP_Text buttonText)
    {
        string cleanedText = buttonText.text.Trim();

        if (string.IsNullOrEmpty(cleanedText)) 
        {
            buttonText.text = turn;
            if (CheckForWin(board)){
                label.text = turn + " won!";
            }
            else 
                if (CheckForFull(board)) {
                    label.text = "It's a tie!";
                }
                else {
                    ChangeTurn();
                }
        }
    }

    private void ChangeTurn()
    {
        if (turn == "X") {
            turn = "O";
            label.text = "O turn";
        }
        else {
            turn = "X";
            label.text = "X turn";
        }
    }

    private bool CheckForWin(TMP_Text[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++) {
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
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                string cleanedText = board[i, j].text.Trim();
                if (string.IsNullOrEmpty(cleanedText)){
                    return false; 
                }
            }
        }
        return true; 
    }
}
