using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessTheNumber : MonoBehaviour
{
    public TMP_InputField inputText;
    public TMP_Text infoText;
    
    private int guessNumber;
    private int userGuess;

    void Start()
    {
        guessNumber = Random.Range(0, 100);
    }

    public void CheckGuess()
    {
        userGuess = int.Parse(inputText.text);
            
        if(guessNumber == userGuess)
        {
            infoText.text = "Hola..!! you guessed the Number :)";
        }
        else if (guessNumber > userGuess)
        {
            infoText.text = "Guessed number is greater than your number";
        }
        else
        {
            infoText.text = "Guessed number is lower than you number";
        }

        inputText.text = "";
    }
    
}
