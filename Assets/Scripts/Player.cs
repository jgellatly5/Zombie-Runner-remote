﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Transform playerSpawnPoints; // the parent of the spawn points
    public GameObject landingAreaPrefab;

    private bool reSpawn = false;
    private Transform[] spawnPoints;
    private bool lastRespawnToggle = false;

    // Use this for initialization
    void Start () {
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(lastRespawnToggle != reSpawn)
        {
            ReSpawn();
            reSpawn = false;
        }
        else
        {
            lastRespawnToggle = reSpawn;
        }
	}

    void ReSpawn()
    {
        int i = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[i].transform.position;
        
    }

    void OnFindClearArea()
    {
        Invoke("DropFlare", 3f);
    }

    void DropFlare()
    {
        Instantiate(landingAreaPrefab, transform.position, transform.rotation);
    }
}
