using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] bool gameisActive;
    [SerializeField] bool gameOver;


    [Header("Timer Settings")]
    public float currentTime;


    
    void Start()
    {
        gameisActive = true;
        gameOver = false;
    }

    
    void Update()
    {
        if (gameisActive && !gameOver)
        {
            currentTime = currentTime += Time.deltaTime;
            SetTimerText();
        }
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0");
    }


    public void MenuButtonClicked()
    {
        SceneManager.LoadScene(sceneBuildIndex:0);
    }
}