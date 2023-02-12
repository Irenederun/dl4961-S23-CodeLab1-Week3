using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;//initial score
    private int level = 0;//level No.
    private int targetScore = 4;//target
    private int record = 2;//existing record
    public bool beat_high_score = false;

    public GameObject showOnGO;
    public GameObject music;
    public GameObject beginText;
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI gameOverText;
    public GameObject inputField;
    public GameObject submitButton;

    private string recordKeeperName = "<???>";//initialize name string
    
    public int Score
    {
        get
        {
            return score;//allow other places to access score through Score
        }
        set
        {
            score = value;//allow score to be set to diff. values

            if (score > Record)//if record is broken
            {
                Record = score;//record sets to new record
                beat_high_score = true;//boolean
                PlayerPrefs.SetString("playerName", "YOU");//change default name display
            }
        }
    }

    public int Record
    {
        get
        {
            record = PlayerPrefs.GetInt("newRecord", 2);//set record to stored player pref data
            recordKeeperName = PlayerPrefs.GetString("playerName", "<???>");//set name to stored player pref data
            return record;//connect Record with record
        }
        set
        {
            record = value;//allow changes to record
            //Debug.Log("New Record!");
            PlayerPrefs.SetInt("newRecord", record);//store new record data into player Pref 
        }
    }
    
    private void Awake()
    {
        if (Instance == null)
            //if no other instance of this game object in scene
        {
            DontDestroyOnLoad(gameObject);
            //don't destroy
            Instance = this;
            //set instance to this one
        }
        else
            //if there is
        {
            Destroy(gameObject);
            //destroy self
        }
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text =
            ("Level: " + (1 + level) + "\n" +
             "Score: " + Score + "\n" +
             "Record: " + Record + " By " + recordKeeperName);//set displayed info text

        if (GameOver.gameOver == true)//if game over. boolean from Game over Script bc public static.
        {
            Destroy(music);//stop music
            Destroy(beginText);//remove game guide
            showOnGO.SetActive(true);//display game over page

            if (beat_high_score == false)//if high score is not broken
            {
                gameOverText.text = "Too Bad! You didn't Beat the Record." + "\n" +
                                    "Try again! Maybe Use Space to Reset?";
                //set text to a diff. version
                
                inputField.SetActive(false);//does not allow for name input
                submitButton.SetActive(false);//does not allow for text submission
            }
            else
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.Space))//press space to reset name and record
        {
            PlayerPrefs.DeleteKey("newRecord");
            PlayerPrefs.DeleteKey("playerName");
        }

        if (Score == targetScore)
            //if reaching target score
        {
            targetScore = targetScore *2;
            //reset targetScore
            level++;
            //increase level
            SceneManager.LoadScene(level);
            //load level
        }
    }
}
