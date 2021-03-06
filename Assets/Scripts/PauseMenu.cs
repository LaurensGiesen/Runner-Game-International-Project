using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public string PlayGameLevel;
    public GameObject pauseMenu;
    public bool deathMenuActive = false;

    public void PauseGame() {
        if (deathMenuActive == false) {
            Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        }
        
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Application.LoadLevel(PlayGameLevel);
    }

    public void QuitToMain() {
        Time.timeScale = 1f;
        Application.LoadLevel(mainMenuLevel);
    }
}
