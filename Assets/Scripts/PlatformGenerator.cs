using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public ObjectPooler theObjectPool;

    public CoinGenerator theCoinGenerator;

 
    // Start is called before the first frame update
    void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        theCoinGenerator = FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x) {

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate(thePlatform, transform.position, transform.rotation);
            GameObject newPlatform = theObjectPool.GetPooledObject(); 

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }
    }
}
