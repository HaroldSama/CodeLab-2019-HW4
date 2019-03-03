using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//USAGE: Attach this to the Anchor of the Destination Petal to trigger events when level finished
public class LevelFinish : MonoBehaviour
{
    [Header("Finish Board")]
    public GameObject board;
    private bool finish;
    private KeyCode next;
    public Text YourStepsNum;
    public Text LeastStepNum;
    public Text ToProcess;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        next = GameManager.Instance.JumpKey;
        ToProcess.text = "Press [" + GameManager.Instance.JumpKey.ToString() + "] to continue...";
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.Find("Player") != null && !finish)
        {
            finish = true;
            board.SetActive(true);
            GameManager.Instance.LeastStep = GameManager.Instance.step;
            YourStepsNum.text = "" + GameManager.Instance.step;
            LeastStepNum.text = "" + GameManager.Instance.leastStep;
        }

        if (finish && Input.GetKeyDown(next))
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);            
        }
    }
}
