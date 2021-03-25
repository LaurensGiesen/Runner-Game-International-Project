using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public string PlayGameLevel;

    public void RestartGame() {
        Application.LoadLevel(PlayGameLevel);
    }

    public void QuitToMain() {
        Application.LoadLevel(mainMenuLevel);
    }
}
