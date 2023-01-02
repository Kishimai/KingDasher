using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject _mainMenu;
    public GameObject _settings;

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Play();
        } else if(Input.GetKeyDown(KeyCode.LeftAlt)){
            ChangePanel("Settings");
        } else if(Input.GetKeyDown(KeyCode.LeftControl)){
            Quit();
        }
    }

    public void Play(){ // Loads the Game
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Quit(){ // To Quit the Game
        Application.Quit();
    }

    /// <summary>
    /// One of the Main Function used on the Main Menu
    /// </summary>
    /// <param name="function">To use on Identifyin the Intention of the Trigger, Back/Settings</param>
    public void ChangePanel(string function){
        switch(function){
            case "Settings":
                _mainMenu.SetActive(false);
                _settings.SetActive(true);
                break;
            case "Back":
                _mainMenu.SetActive(true);
                _settings.SetActive(false);
                break;
        }
    }
}
