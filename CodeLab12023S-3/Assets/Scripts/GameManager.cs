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

    private int score = 0;
    private int level = 0;
    private int targetScore = 4;
    private int record = 2;
    public bool beat_high_score = false;

    public GameObject showOnGO;
    public GameObject music;
    public GameObject beginText;
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI gameOverText;

    private string recordKeeperName = "<???>";
    
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;

            if (score > Record)
            {
                Record = score;
                beat_high_score = true;
                //PlayerPrefs.SetString("playerName", "YOU");
            }
        }
    }

    public int Record
    {
        get
        {
            record = PlayerPrefs.GetInt("newRecord", 2);
            recordKeeperName = PlayerPrefs.GetString("playerName", "<???>");
            return record;
        }
        set
        {
            record = value;
            //Debug.Log("New Record!");
            PlayerPrefs.SetInt("newRecord", record);
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
             "Record: " + Record + " By " + recordKeeperName);

        if (GameOver.gameOver == true)
        {
            Destroy(music);
            Destroy(beginText);
            showOnGO.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Space))
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
