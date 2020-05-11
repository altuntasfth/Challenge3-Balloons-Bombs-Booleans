using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefs;
    private Vector3 spawnPos;
    private float spawnPosX = 22.0f;
    private float spawnPosY;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("ObjectSpawn", startDelay, spawnInterval);
    }


    void ObjectSpawn()
    {
        spawnPosY = Random.Range(5, 15);
        spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
        int randObj = Random.Range(0, objectPrefs.Length);
        if (!playerController.gameOver)
        {
            Instantiate(objectPrefs[randObj], spawnPos, objectPrefs[randObj].transform.rotation);
        }
        
    }
}
