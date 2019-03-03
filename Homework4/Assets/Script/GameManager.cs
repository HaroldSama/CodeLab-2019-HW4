using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Scoring System")]
    public int step;
    public Text stepText;

    public int Step
    {
        get { return step; }
        set
        {
            step = value;
            stepText.text = "Steps: " + step;
        }
    }

    public int miss;
    public Text missText;

    public int Miss
    {
        get { return miss; }
        set
        {
            miss = value;
            missText.text = "Miss: " + miss;
        }
    }
    
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
                leastStepList[SceneManager.GetActiveScene().buildIndex] = leastStep;
            }
        }
    }
    
    public List<int> leastStepList;
    
    [Header("Player Setting")]
    public float SlidingSpeed;
    public KeyCode JumpKey;

    public static GameManager Instance;
    
    private void Awake()
    {
        //destroy the gameManager object if there's more than one instance
        if (Instance == null)
        {
            Instance = this; // set the instance to this script
            DontDestroyOnLoad(gameObject);
            
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                leastStepList.Add(0);
            }
            
            leastStepList[SceneManager.GetActiveScene().buildIndex] = leastStep;
            leastStepText.text = "Least Steps: " + leastStep;
        }
        else
        {
            //Pass information to the previous GameManager
            Instance.stepText = stepText;
            Instance.missText = missText;
            Instance.leastStepText = leastStepText;
            Instance.step = step;
            Instance.miss = miss;
            if (Instance.leastStepList[SceneManager.GetActiveScene().buildIndex] == 0)//Which means the list hasn't pick up the number yet.
            {
                Instance.leastStepList[SceneManager.GetActiveScene().buildIndex] = leastStep;                
            }
            Instance.leastStep = Instance.leastStepList[SceneManager.GetActiveScene().buildIndex];
            Instance.leastStepText.text = "Least Steps: " + Instance.leastStep;
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
