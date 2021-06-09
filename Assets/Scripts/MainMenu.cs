using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
  public void onExitButton()
    {
        Application.Quit();
    }


  public void onPlayButton()
    {
        SceneManager.LoadScene(1);
    }

}
