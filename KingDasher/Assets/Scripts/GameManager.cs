using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _deathMenu;
    public GameObject _pauseMenu;
    [Space] // Text Variables
    public TMP_Text _countDownText; // 3d Texts Viewd In-Game
    public TMP_Text _totalDeathText; 
    public TMP_Text _totalPointsText;
    public TMP_Text _totalWaveText;
    [Space]
    public TMP_Text _totalPointsDeath; // Text on the death menu
    [Space]
    public TMP_Text _totalPointsPause; // Texts on the Pause Menu
    public TMP_Text _totalWavePause;
    public TMP_Text _totalHighScorePause;
    public TMP_Text _totalDeathPause;
    [Space]
    public BlockSpawner _spawner; // to get information on _points
    public PlayerMovement _player;
    public HighScoreManager _scoreManager; // Used to Set & Get the Highscore
    [Space]
    public bool _paused = false; // used on pausing the game and entering the pause menu

    void Update(){
        // INGAME 3D TEXTS
        _countDownText.text = _spawner._countdown.ToString("0");
        _totalDeathText.text = $"DEATH {_player._deaths} / {_player._deathLimit}";
        _totalPointsText.text = $"POINTS {_spawner._points}";
        _totalWaveText.text = $"WAVE {_spawner._currentWave}";

        // DEATH MENU
        if(_spawner._points > _scoreManager.HighScore){
            _totalPointsDeath.text = $"NEW HIGHSCORE {_spawner._points}!!";
        } else{
            _totalPointsDeath.text = $"You got {_spawner._points}! ";
        }

        // PAUSED MENU
        _totalPointsPause.text = $"SCORE: {_spawner._points}";
        _totalDeathPause.text = $"DEATH {_player._deaths} / {_player._deathLimit}";
        _totalWavePause.text = $"WAVE: {_spawner._currentWave}";
        _totalHighScorePause.text = $"HIGHSCORE: {_scoreManager.HighScore}";


        if(Input.GetKeyDown(KeyCode.Escape)){
            Pause(); // Pauses the Game and Enters the Pause Menu
        }
    }

    /// <summary>
    /// Opens the Death Menu, with the Option to either repeat the game or go to the menu
    /// </summary>
    /// <param name="function">Three functions, Died/Restart/Menu</param>
    public void Died(string function){
        switch(function){
            case "Died":
                _deathMenu.SetActive(true);
                Time.timeScale = 0;

                if(_spawner._points > _scoreManager.HighScore){
                    _scoreManager.SaveHighScore(_spawner._points);
                }
                
                return;
            case "Restart":
                _deathMenu.SetActive(false);
                _spawner._points = 0;
                _player._deaths = 0;
                _spawner._countdown = 5;
                Time.timeScale = 1;
                return;
            case "Menu":
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
                return;
        }
    }

    public void Pause(){
        if(_paused == false){
            _pauseMenu.SetActive(true);
            _paused = true;
            Time.timeScale = 0;
        } else if(_paused == true){
            _pauseMenu.SetActive(false);
            _paused = false;
            Time.timeScale = 1;
        }
    }
}
