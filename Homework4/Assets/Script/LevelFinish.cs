using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour
{
    public int leastStep;
    public Text leastStepText;

    public int LeastStep
    {
        get { return leastStep; }
        set
        {
            if (value < leastStep)
            {
                leastStep = value;
                leastStepText.text = "Least Steps: " + leastStep;
            }
        }
    }

    public GameObject board;
    private bool finish;
    private KeyCode next;
    public Text YourStepsNum;
    public Text LeastStepNum;
    
    // Start is called before the first frame update
    void Start()
    {
        next = GameManager.Instance.JumpKey;
        leastStepText.text = "Least Steps: " + leastStep;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.Find("Player") != null)
        {
            finish = true;
            board.SetActive(true);
            LeastStep = GameManager.Instance.step;
            YourStepsNum.text = "" + GameManager.Instance.step;
            LeastStepNum.text = "" + leastStep;
        }

        if (finish && Input.GetKeyDown(next))
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);            
        }
    }
}
