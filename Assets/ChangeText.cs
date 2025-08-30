using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public TMP_Text buttonText;
    private List<string> textChoices;
    private int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textChoices = new List<string>();
        textChoices.Add("X");
        textChoices.Add("O");
        textChoices.Add(" ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newText()
    {
        buttonText.text = textChoices[i];
        i = (i + 1) % 3;
    }
}
