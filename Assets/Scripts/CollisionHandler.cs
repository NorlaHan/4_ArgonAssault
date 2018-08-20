using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Ok as ling as this is the only script that loads scene

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float levelDelay = 1f;
    [Tooltip("In seconds")][SerializeField] int crashPenalty = -10;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    ScoreBoard scoreBoard;
    private void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemies")
        {
            print("Player Hit enemies");
        }
        else
        {
            print("Player Hit " + other.name);
        }
        scoreBoard.OnScoreHit(crashPenalty);
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        // Invoke("OnReloadScene",levelDelay);
    }

    private void OnReloadScene()    // String reference
    {
        SceneManager.LoadScene(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(name + ", hit " + collision.gameObject.name);
    }
}
