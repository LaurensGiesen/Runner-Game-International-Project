using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {
    private bool doublePoints;
    private bool safeMode;
    private bool powerupActive;
    private float powerupLengthCounter;
    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;
    private GameManager theGameManager;
    private float normalPointsPerSecond;
    private bool upgradedPoints;
    private float spikeRate;
    private PlatformDestroyer[] spikeList;
    // Start is called before the first frame update
    void Start() {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        theGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        if (powerupActive) {
            powerupLengthCounter -= Time.deltaTime;
            if (theGameManager.powerupReset) {
                powerupLengthCounter = 0;
                theGameManager.powerupReset = false;
            }
            if (doublePoints) {
                if (upgradedPoints == false) {
                    theScoreManager.pointsPerSecond = theScoreManager.pointsPerSecond * 2.75f;
                }
                upgradedPoints = true;
                theScoreManager.shouldDouble = true;
            }
            if (safeMode) {
                thePlatformGenerator.randomSpikeThreshold = 0f;
            }
            if (powerupLengthCounter <= 0) {
                theScoreManager.pointsPerSecond = theScoreManager.pointsPerSecond / 2.75f;
                theScoreManager.shouldDouble = false;
                thePlatformGenerator.randomSpikeThreshold = spikeRate;
                powerupActive = false;
                upgradedPoints = false;
            }
        }
    }
    
    public void ActivatePowerup(bool points, bool safe, float time) {
        doublePoints = points;
        safeMode = safe;
        powerupLengthCounter = time;
        
        spikeRate = thePlatformGenerator.randomSpikeThreshold;
        if (safeMode) {
            spikeList = FindObjectsOfType<PlatformDestroyer>();
            for(int i = 0;i < spikeList.Length; i++) {
                if (spikeList[i].gameObject.name.Contains("spikes")) {
                     spikeList[i].gameObject.SetActive(false);
                }
            }
        }
        powerupActive = true;
    }
}
