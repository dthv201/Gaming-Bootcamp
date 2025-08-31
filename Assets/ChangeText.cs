using System;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public TMP_Text label;

    public TMP_Text topleft, top, topright;
    public TMP_Text left, mid, right;
    public TMP_Text botleft, bottom, botright;

    private TMP_Text[,] board;
    private int num_turns;
    private string curr_turn;

    void Start()
    {
        board = new TMP_Text[,] {
            { topleft,  top,    topright },
            { left,     mid,    right },
            { botleft,  bottom, botright }
        };
        curr_turn = "X";
        num_turns = 0;
    }

    void Update()
    {

    }
    public void OnButtonClick(TMP_Text btn_text)
    {
        if (string.IsNullOrWhiteSpace(btn_text.text))
        {
            num_turns++;
            btn_text.text = curr_turn;

            if (num_turns < 3)
            {
                NextTurn();
                return;
            }

            if (IsWin())
            {
                label.text = curr_turn + " wins!";
                return;
            }
            if (IsBoardFull())
            {
                label.text = "It's a tie!";
                return;
            }

            NextTurn();
        }
    }

    private void NextTurn()
    {
        if (num_turns % 2 == 0)
        {
            curr_turn = "X";
        }
        else
        {
            curr_turn = "O";
        }

        label.text = curr_turn + " turn";
    }

    private bool IsBoardFull()
    {
        return num_turns == 9;
    }

    private bool IsWin()
    {
        //crosses
        if (IsEqualThree(board[0, 0].text, board[1, 1].text, board[2, 2].text))
        {
            return true;
        }

        if (IsEqualThree(board[0, 2].text, board[1, 1].text, board[2, 0].text))
        {
            return true;
        }

        //rows and cols
        for (int i = 0; i < board.GetLength(0); i++)
        {
            if (IsEqualThree(board[i, 0].text, board[i, 1].text, board[i, 2].text))
            {
                return true;
            }
            if (IsEqualThree(board[0, i].text, board[1, i].text, board[2, i].text))
            {
                return true;
            }

        }
        return false;
    }

    private bool IsEqualThree(string t1, string t2, string t3)
    {
        if (string.IsNullOrWhiteSpace(t1))
        {
            return false;
        }
        return t1 == t2 && t3 == t1;
    }
}
