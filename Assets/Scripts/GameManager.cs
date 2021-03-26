using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;
    public PlayerController thePlayer;
    private Vector3 playerStartPoint;
    private PlatformDestroyer[] platformList;
    private ScoreManager theScoreManager;
    private PauseMenu thePauseMenu;
    public DeathMenu theDeathScreen;
    public bool powerupReset;

    // Start is called before the first frame update
    void Start() {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
		theScoreManager = FindObjectOfType<ScoreManager>();
        thePauseMenu = FindObjectOfType<PauseMenu>(); 
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void RestartGame() {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        theDeathScreen.gameObject.SetActive(true);
        thePauseMenu.deathMenuActive = true;
    }

    public void Reset() {
        theDeathScreen.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0;i < platformList.Length; i++) {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
        powerupReset = true;
    }
}
