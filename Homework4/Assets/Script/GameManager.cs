using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Scoring System")]
    public int perfect;
    public Text perfectText;

    public int Perfect
    {
        get { return perfect; }
        set
        {
            perfect = value;
            perfectText.text = "Perfect: " + perfect;
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
        }
        else
        {
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
