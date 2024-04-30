using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using System.IO;


public class MenuUIHandler : MonoBehaviour
{
   

    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);//loads the main scene

    }

    public void ExitGame()
    {
        
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode(); //Quits play mode
        }
        else
        {
            Application.Quit(); //Quits application after game is built
        }
    }

    
}
