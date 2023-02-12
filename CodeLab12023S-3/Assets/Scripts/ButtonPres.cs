using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonPres : MonoBehaviour
{
    private string playerName;
    public static string nickName;
    public string replacementText;
    private string winnerNamePlayerPref;

    public GameObject inputField;
    public GameObject submitButton;
    public TextMeshProUGUI recordName;
    public TextMeshProUGUI gameOverText;

    public void SubmitName()//on submission button clicked 
    {
        playerName = recordName.text;//get the input text 
        string[] nameParts = playerName.Split(' ');//split between parts
        nickName = nameParts[0];//take only the first part
        gameOverText.text = replacementText.Replace("<name>", nickName);//change display text
        
        Destroy(inputField);//remove input field
        Destroy(submitButton);//remove submission button

        PlayerPrefs.SetString("playerName", nickName);//store input name as the new player name in player pref 
        
        Debug.Log("Name: " + nickName);//debug
    }
}
