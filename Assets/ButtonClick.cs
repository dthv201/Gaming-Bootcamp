using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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



    private string turn = "X";
    public void ButtonOnClick(TMP_Text buttonText)
    {
        //if (!(buttonText.Equals("X") || buttonText.Equals("O"))) {
        string cleanedText = buttonText.text.Trim();
        if (string.IsNullOrEmpty(cleanedText))
            {
            buttonText.text = turn;
            ChangeTurn();
        }
        
    }

    private void ChangeTurn()
    {
        if (turn == "X") { turn = "O"; }
        else { turn = "X"; }
    }
}
