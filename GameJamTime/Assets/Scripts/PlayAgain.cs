using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour
{
    public Button playAgain;


    void Start()
    {
        playAgain.onClick.AddListener(pressed);
    }


    void Update()
    {
        
    }

    public void pressed()
    {
        SceneManager.LoadScene("MAIN");
    }

}
