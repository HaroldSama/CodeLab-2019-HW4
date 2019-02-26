using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text scoreText;
    private int score;

    public Text highScoreText;
    private int highScore;

    private const string PLAYER_PREF_HIGHSCORE = "highScore";
    private const string FILE_HIGH_SCORE = "/MyHighScoreFile.txt";

    

    public int HighScore
    {
        get { return highScore; }
        set
        {
            if (value > highScore)
            {
                highScore = value;
                highScoreText.text = "High Score: " + highScore;
                //PlayerPrefs.SetInt(PLAYER_PREF_HIGHSCORE, highScore);

                Debug.Log(Application.dataPath);
                string fullPathToFile = Application.dataPath + FILE_HIGH_SCORE;

                /*if (File.Exists(fullPathToFile))
                {*/
                    File.WriteAllText(fullPathToFile, "HighScore: " + highScore);
                    /*Debug.Log("The File Does Exist");
                }
                else
                {
                    Debug.Log("The File Doesn't Exist");
                }*/
            }
        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
            scoreText.text = "Score: " + score;
            HighScore = score;
        }
    }

    public static GameManager instance;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //HighScore = PlayerPrefs.GetInt(PLAYER_PREF_HIGHSCORE, 10);

        string highScoreFileText = File.ReadAllText(Application.dataPath + FILE_HIGH_SCORE);

        string[] scoreSplit = highScoreFileText.Split(' ');
        
        HighScore = Int32.Parse(scoreSplit[1]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
