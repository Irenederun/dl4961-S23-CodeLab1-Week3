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

    public void SubmitName()
    {
        playerName = recordName.text;
        string[] nameParts = playerName.Split(' ');
        nickName = nameParts[0];
        gameOverText.text = replacementText.Replace("<name>", nickName);
        
        Destroy(inputField);
        Destroy(submitButton);

        PlayerPrefs.SetString("playerName", nickName);
        
        Debug.Log("Name: " + nickName);
    }
}
