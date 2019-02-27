using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LeastSteps : MonoBehaviour
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

    public static LeastSteps instance;
    
    // Start is called before the first frame update
    void Start()
    {
        leastStepText.text = "Least Steps: " + leastStep;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
