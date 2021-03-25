using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;

    public void RestartGame() {

    }

    public void QuitToMain() {
        Application.LoadLevel(mainMenuLevel);
    }
}
