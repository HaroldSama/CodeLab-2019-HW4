using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                leastStepListStr[SceneManager.GetActiveScene().buildIndex] = leastStep.ToString();
                File.WriteAllLines(Application.dataPath + FILE_LEAST_STEPS, leastStepListStr);
                
            }
        }
    }
    
    public List<int> leastStepList;
    public List<string> leastStepListStr;
    
    [Header("Player Setting")]
    public float SlidingSpeed;
    public KeyCode JumpKey;

    public static GameManager Instance;
    
    private const string FILE_LEAST_STEPS = "/MyLeastStepsFile.txt";
    
    private void Awake()
    {
        Debug.Log(Application.dataPath);
        string fullPathToFile = Application.dataPath + FILE_LEAST_STEPS;
        int index = SceneManager.GetActiveScene().buildIndex;//Use the as index because the least steps list will be build according to the level order.

        if (File.Exists(fullPathToFile))//if the file is found, read it into the Least Step List
        {
            leastStepListStr = File.ReadAllLines(fullPathToFile).ToList();
            for (int i = 0; i < leastStepListStr.Count; i++)
            {
                leastStepList.Add(Int32.Parse(leastStepListStr[i]));
            }
        }
        else//if the file is not fount, create the Least Step List with all numbers as "0"
        {
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                leastStepList.Add(0);
                leastStepListStr.Add("0");
            }                       
        }
        
        //destroy the gameManager object if there's more than one instance
        if (Instance == null)
        {
            Instance = this; // set the instance to this script

            if (leastStepList[index] == 0)//Which means the list hasn't pick up the number yet.
            {
                leastStepList[index] = leastStep;//Write the default information to the list
                leastStepListStr[index] = leastStep.ToString();
                File.WriteAllLines(fullPathToFile, leastStepListStr); //Write the updated information to the file             
            }
            
            leastStep = leastStepList[index];
            leastStepText.text = "Least Steps: " + leastStep;
            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Pass information to the current GameManager
            Instance.stepText = stepText;
            Instance.missText = missText;
            Instance.leastStepText = leastStepText;
            Instance.step = step;
            Instance.miss = miss;
            
            if (Instance.leastStepList[index] == 0)//Which means the list hasn't pick up the number yet.
            {
                Instance.leastStepList[index] = leastStep;//This script pass the default number of the least step to the current GameManger
                Instance.leastStepListStr[index] = leastStep.ToString();
                File.WriteAllLines(fullPathToFile, leastStepListStr); //Write the updated information to the file
            }
            
            Instance.leastStep = Instance.leastStepList[index];
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
